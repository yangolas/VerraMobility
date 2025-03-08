using Prueba2.Domain.Enums;
using System.ComponentModel;
using System.IO;

namespace Prueba2.Domain.ValueObjects;

public record class Address
{
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; }
    public string ZipCode { get; set; } = null!;
    public StatusAdress StatusAdress { get; set; }
    
    public Address(
        string street, 
        string city, 
        string state, 
        string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public void SetStreet(string street) 
    {
        NormaliceStreet(street);
        Street = street;
    }

    public void SetState(string state)
    {
        NormaliceState(state);
        State = state;
    }

    public void NormaliceStreet(string street) 
    { 
    
    }

    public void NormaliceState(string street)
    {
        //State? state  = street.switch() => 
        //{
        //    State.NY.GetDescription() || State.NY.ToString() => return State.NY 
        //    State.CA.GetDescription() || State.CA.ToString()=> return State.CA 
        //    State.IL.GetDescription() || State.IL.ToString()=> return State.IL
        //    default => null
        //}
        //if(state == )
    }
}