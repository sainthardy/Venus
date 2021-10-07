using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Venus.Models
{
    public class RegistrationApproval
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string NPWP { get; set; }
        public string FieldOfBusiness { get; set; }
        public string PICName { get; set; }
        public string PICEmail { get; set; }
    }
}
