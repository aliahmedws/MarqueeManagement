import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface BookingMenuOptionDto extends EntityDto<string> {
  quantity: number;
  price: number;
}

export interface CreateBookingMenuOptionDto {
  quantity: number;
  price: number;
}

export interface GetBookingMenuOptionListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}

export interface UpdateBookingMenuOptionDto {
  quantity: number;
  price: number;
}
