using System;
using Microsoft.AspNetCore.Identity;


namespace Domain
{

public class Patients 
{
    public Guid PatientId{get;set;}
    public string FirstName{get;set;}
    public string LastName{get;set;}
    public string Gender{get;set;}
    public string DateOfBirth{get;set;}
    public string AddressLine1{get; set;}
    public string AddressLine2{get;set;}
    public string City{get;set;}
    public string State{get;set;}
    public string PostalCode{get;set;}

}
}
