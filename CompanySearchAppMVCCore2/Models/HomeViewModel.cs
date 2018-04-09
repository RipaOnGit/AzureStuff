using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanySearchAppMVCCore2.Models
{
    public class HomeViewModel
    {
        //public RootObject QueryResult { get; set; }
        public string Name { get; set; }
        public string YTunnus { get; set; }

        public List<RegistedOffice> Toimipaikat { get; set; }
    }



    public class Name
    {
        public int order { get; set; }
        public int version { get; set; }
        public string name { get; set; }
        public string registrationDate { get; set; }
        public object endDate { get; set; }
        public int source { get; set; }
    }

    public class Address
    {
        public object careOf { get; set; }
        public string street { get; set; }
        public string postCode { get; set; }
        public int type { get; set; }
        public int version { get; set; }
        public string city { get; set; }
        public object country { get; set; }
        public string registrationDate { get; set; }
        public object endDate { get; set; }
        public string language { get; set; }
        public int source { get; set; }
    }

    public class CompanyForm
    {
        public int version { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string registrationDate { get; set; }
        public object endDate { get; set; }
        public string language { get; set; }
        public int source { get; set; }
    }

    public class BusinessLine
    {
        public int order { get; set; }
        public int version { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string registrationDate { get; set; }
        public object endDate { get; set; }
        public string language { get; set; }
        public int source { get; set; }
    }

    public class Language
    {
        public int version { get; set; }
        public string name { get; set; }
        public string registrationDate { get; set; }
        public object endDate { get; set; }
        public string language { get; set; }
        public int source { get; set; }
    }

    public class RegistedOffice
    {
        public int order { get; set; }
        public int version { get; set; }
        public string name { get; set; }
        public string registrationDate { get; set; }
        public string endDate { get; set; }
        public string language { get; set; }
        public int source { get; set; }
    }

    public class RegisteredEntry
    {
        public int authority { get; set; }
        public int register { get; set; }
        public int status { get; set; }
        public string registrationDate { get; set; }
        public object endDate { get; set; }
        public string statusDate { get; set; }
        public string language { get; set; }
        public string description { get; set; }
    }

    public class Result
    {
        public string businessId { get; set; }
        public string name { get; set; }
        public string registrationDate { get; set; }
        public string companyForm { get; set; }
        public object detailsUri { get; set; }
        public List<object> liquidations { get; set; }
        public List<Name> names { get; set; }
        public List<object> auxiliaryNames { get; set; }
        public List<Address> addresses { get; set; }
        public List<CompanyForm> companyForms { get; set; }
        public List<BusinessLine> businessLines { get; set; }
        public List<Language> languages { get; set; }
        public List<RegistedOffice> registedOffices { get; set; }
        public List<object> contactDetails { get; set; }
        public List<RegisteredEntry> registeredEntries { get; set; }
        public List<object> businessIdChanges { get; set; }
    }

    public class RootObject
    {
        public string type { get; set; }
        public string version { get; set; }
        public int totalResults { get; set; }
        public int resultsFrom { get; set; }
        public object previousResultsUri { get; set; }
        public object nextResultsUri { get; set; }
        public object exceptionNoticeUri { get; set; }
        public List<Result> results { get; set; }
    }
}
