import { Component, OnInit } from '@angular/core';
import { CoreModule, ListService, LocalizationModule, PagedResultDto } from '@abp/ng.core';
import { BookingDto, GetBookingListDto, CreateBookingDto, UpdateBookingDto } from '../proxy/bookings';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgbDateAdapter, NgbDateNativeAdapter, NgbDatepickerModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';
import { CardModule, ConfirmationService, Confirmation, ModalComponent, ToasterService } from '@abp/ng.theme.shared';
import { BookingService } from '../proxy/controllers';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { PageModule } from '@abp/ng.components/page';
//import { ListModule } from '@abp/ng.components/list';

@Component({
  standalone: true,
  selector: 'app-bookings',
  templateUrl: './bookings.html',
  styleUrls: ['./bookings.scss'],
  imports: [
  CommonModule,
  FormsModule,
  ReactiveFormsModule,
  CardModule,
  NgbDatepickerModule,
  NgbDropdownModule,
  ModalComponent,
  NgxDatatableModule,
  PageModule,
  LocalizationModule,
  CoreModule 
  //ListModule
],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class Bookings implements OnInit {
  bookings = { items: [], totalCount: 0 } as PagedResultDto<BookingDto>;
  isModalOpen = false;
  showFilter = false;
  form: FormGroup;
  selectedBooking = {} as BookingDto;
  filters = {} as GetBookingListDto;

  constructor(
    public readonly list: ListService,
    private bookingService: BookingService, 
    private toaster: ToasterService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit(): void {
    const bookingStreamCreator = (query) =>
      this.bookingService.getList({ ...query, ...this.filters });
    this.list.hookToQuery(bookingStreamCreator).subscribe((response: PagedResultDto<BookingDto>) => {
      this.bookings = response;
    });
  }

  // FORM
  buildForm(): void {
    this.form = this.fb.group({
      eventDate: [this.selectedBooking.eventDate || '', Validators.required],
      eventType: [this.selectedBooking.eventType || '', Validators.required],
      guestCount: [this.selectedBooking.guestCount || null, Validators.required],
      totalAmount: [this.selectedBooking.totalAmount || null, Validators.required],
      status: [this.selectedBooking.status || '', Validators.required],
    });
  }

  // CREATE
  createBooking(): void {
    this.selectedBooking = {} as BookingDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  // EDIT
  editBooking(id: string): void {
    this.bookingService.get(id).subscribe((booking) => {
      this.selectedBooking = booking;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  // DELETE
  delete(id: string): void {
    this.confirmation
      .warn('ARE YOU SURE YOU WANT TO DELETE?', 'DELETE CONFIRMATION')
      .subscribe((status) => {
        if (status === Confirmation.Status.confirm) {
          this.bookingService.delete(id).subscribe(() => {
            this.list.get();
            this.toaster.success('Deleted Successfully');
          });
        }
      });
  }

  // CLEAR FILTERS
clearFilters(): void {
  this.filters = {} as GetBookingListDto;
  this.list.get();
}

  // SAVE
  save(): void {
    if (this.form.invalid) {
      return;
    }

    if (this.selectedBooking?.id && !this.form.dirty) {
      this.toaster.info('Nothing changed');
      return;
    }

    const bookingData = this.form.value;

    if (this.selectedBooking.id) {
      this.bookingService.update(this.selectedBooking.id, bookingData).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
        this.toaster.success('Updated Successfully');
      });
    } else {
      this.bookingService.create(bookingData).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
        this.toaster.success('Created Successfully');
      });
    }
  }
}