using System;
using Microsoft.AspNetCore.Identity;


namespace Application
{

public class PatientsDTO
{
    public String PatientId{get;set;}
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
