using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Microsoft.Extensions.DependencyInjection;

namespace BlushMe.Model
{
    public class Appointment
    {
        [Key] public int AppointmentId { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int MetaId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Status { get; set; }
        public string Title { get; set; }
        public string ServicesId { get; set; }

        public Meta Meta { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Client Client { get; set; }
    }
}