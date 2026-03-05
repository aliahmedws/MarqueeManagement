using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace MarqueeManagement.Bookings;

public class Booking : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public DateTime EventDate { get; set; }
    public string EventType { get; set; }
    public int GuestCount { get; set; }
    public decimal TotalAmount { get; set; }
    public BookingStatus Status { get; set; }
    public Guid? TenantId { get; set; }

    private Booking()
    {
    }

    internal Booking(
        Guid id,
        DateTime eventDate,
        string eventType,
        int guestCount,
        decimal totalAmount,
        BookingStatus status
    ) : base(id)
    {
         EventDate = eventDate;
         EventType = eventType;
         GuestCount = guestCount;
         TotalAmount = totalAmount;
         Status = status;
    }
}