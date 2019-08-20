using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BlushMe.Model;

namespace BlushMe.Dto
{
    [DataContract]
    public class AppointmentDto
    {
    
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public string Text { get; set; }
            [DataMember]
            public DateTime StartDate { get; set; }
            [DataMember]
            public DateTime EndTime { get; set; }
            [DataMember]
            public int EmployeeId { get; set; }
            [DataMember]
            public string ClientName { get; set; }

    }
}