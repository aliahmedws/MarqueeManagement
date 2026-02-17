using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace MarqueeManagement.Bookings;

public class Booking : FullAuditedAggregateRoot<Guid>
{
    public DateTime EventDate { get; set; }
    public EventType Events { get; set; }
    public int GuestCount { get; set; }
    public string? Description { get; set; }

    private Booking()
    {
        //constructor 
    }
    internal Booking(Guid id, DateTime eventDate, EventType events, int guestCount, string? description)
        : base(id)
    {
        EventDate = eventDate;
        Events = events;
        GuestCount = guestCount;
        SetDescription(description);
    }
private void SetDescription(string? description)
    {
        if (description == null || description.Length > 500)
        {
            throw new UserFriendlyException("Description cannot exceed 500 characters.");
        }
        Description = description;
    }  
}