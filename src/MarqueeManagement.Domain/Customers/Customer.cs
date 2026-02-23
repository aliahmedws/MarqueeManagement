using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace MarqueeManagement.Customers;

public class Customer : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public Guid? TenantId { get; set; }

    public Customer()
    {
    }

    internal Customer(Guid id,
        string Name,
        string phone,
        string email,
        string address
        ) : base(id)
    {
        SetName(Name);
        SetPhone(phone);
        SetEmail(email);
        SetAddress(address);
    }

    internal Customer ChangeDetails(string Name, string phone, string email, string address)
    {
        SetName(Name);
        SetPhone(phone);
        SetEmail(email);
        SetAddress(address);
        return this;
    }

    private void SetName(string Name)
    {
        Name = Check.NotNullOrWhiteSpace(
            Name,
            nameof(Name),
            maxLength: CustomerConsts.MaxNameLength);
    }
    private void SetPhone(string phone)
    {
        Phone = Check.NotNullOrWhiteSpace(
            phone,
            nameof(phone),
            maxLength: CustomerConsts.MaxPhoneLength);
    }
    private void SetEmail(string email)
    {
        Email = Check.NotNullOrWhiteSpace(
            email,
            nameof(email),
            maxLength: CustomerConsts.MaxEmailLength);
    }
    private void SetAddress(string address)
    {
        Address = Check.NotNullOrWhiteSpace(
            address,
            nameof(address),
            maxLength: CustomerConsts.MaxAddressLength);
    }
}
