using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace MarqueeManagement.Customers;

public class Customer : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public Guid? TenantId { get; set; }

    public Customer()
    {
    }

    internal Customer(Guid id,
        string fullName,
        string phone,
        string email,
        string address
        ) : base(id)
    {
        SetFullName(fullName);
        SetPhone(phone);
        SetEmail(email);
        SetAddress(address);
    }

    internal Customer ChangeDetails(string fullName, string phone, string email, string address)
    {
        SetFullName(fullName);
        SetPhone(phone);
        SetEmail(email);
        SetAddress(address);
        return this;
    }

    private void SetFullName(string fullName)
    {
        FullName = Check.NotNullOrWhiteSpace(
            fullName,
            nameof(fullName),
            maxLength: CustomerConsts.MaxFullNameLength);
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
