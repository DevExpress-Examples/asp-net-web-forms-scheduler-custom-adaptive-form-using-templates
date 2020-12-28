using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Helpers {
    public class AppointmentDataSourceHelper {
        public AppointmentDataSourceHelper() { }

        public static List<CustomAppointment> GetCustomAppointmentsList() {
            if(System.Web.HttpContext.Current.Session["CustomAppointmentsList"] == null) {
                List<CustomAppointment> appts = new List<CustomAppointment>();
                List<CustomResource> resourcesList = ResourceDataSourceHelper.GetCustomResources();
                int uniqueID = 0;
                foreach(var resource in resourcesList) {
                    if(resource.ResourceId == 1) {
                        appts.Add(new CustomAppointment() {
                            Id = uniqueID++,
                            AllDay = false,
                            Description = "Some Test Description",
                            StartTime = DateTime.Now.Date.AddHours(12 + resource.ResourceId),
                            EndTime = DateTime.Now.Date.AddHours(15 + resource.ResourceId),
                            EventType = 1,
                            Label = 2,
                            ResourceId = resource.ResourceId,
                            Status = 3,
                            Subject = "Meeting",
                            RecurrenceInfo = "<RecurrenceInfo Start=\"12/25/2020 13:00:00\" End=\"01/21/2021 13:00:00\" Id=\"8dc34c47-fc2b-49db-8f1c-9755c23057aa\" Periodicity=\"3\" Range=\"1\" FirstDayOfWeek=\"0\" Version=\"1\"/>"
                        });                        
                    }
                    else {
                        appts.Add(new CustomAppointment() {
                            Id = uniqueID++,
                            AllDay = false,
                            Description = "Some Test Description",
                            StartTime = DateTime.Now.Date.AddHours(12 + resource.ResourceId),
                            EndTime = DateTime.Now.Date.AddHours(15 + resource.ResourceId),
                            EventType = 0,
                            Label = 2,
                            ResourceId = resource.ResourceId,
                            Status = 3,
                            Subject = "Meeting"
                        });
                    }
                }
                System.Web.HttpContext.Current.Session["CustomAppointmentsList"] = appts;
            }
            return System.Web.HttpContext.Current.Session["CustomAppointmentsList"] as List<CustomAppointment>;
        }

        public static object InsertCustomAppointment(CustomAppointment newCustomAppointment) {
            List<CustomAppointment> CustomAppointments = GetCustomAppointmentsList();

            int lastCustomAppointmentID = CustomAppointments.Count == 0 ? 0 : CustomAppointments.OrderBy(c => c.Id).Last().Id;
            newCustomAppointment.Id = lastCustomAppointmentID + 1;

            CustomAppointments.Add(newCustomAppointment);
            return newCustomAppointment.Id;
        }

        public static void DeleteCustomAppointment(CustomAppointment deletedCustomAppointment) {
            List<CustomAppointment> CustomAppointments = GetCustomAppointmentsList();

            CustomAppointment currentCustomAppointment = CustomAppointments.FirstOrDefault(c => c.Id.Equals(deletedCustomAppointment.Id));
            if(currentCustomAppointment != null) CustomAppointments.Remove(currentCustomAppointment);
        }

        public static void UpdateCustomAppointment(CustomAppointment updatedCustomAppointment) {
            List<CustomAppointment> CustomAppointments = GetCustomAppointmentsList();

            CustomAppointment currentCustomAppointment = CustomAppointments.FirstOrDefault(c => c.Id.Equals(updatedCustomAppointment.Id));
            currentCustomAppointment.AllDay = updatedCustomAppointment.AllDay;
            currentCustomAppointment.Description = updatedCustomAppointment.Description;
            currentCustomAppointment.EndTime = updatedCustomAppointment.EndTime;
            currentCustomAppointment.EventType = updatedCustomAppointment.EventType;
            currentCustomAppointment.Label = updatedCustomAppointment.Label;
            currentCustomAppointment.Location = updatedCustomAppointment.Location;
            currentCustomAppointment.RecurrenceInfo = updatedCustomAppointment.RecurrenceInfo;
            currentCustomAppointment.ReminderInfo = updatedCustomAppointment.ReminderInfo;
            currentCustomAppointment.ResourceId = updatedCustomAppointment.ResourceId;
            currentCustomAppointment.StartTime = updatedCustomAppointment.StartTime;
            currentCustomAppointment.Status = updatedCustomAppointment.Status;
            currentCustomAppointment.Subject = updatedCustomAppointment.Subject;

            currentCustomAppointment.CustomInfo = updatedCustomAppointment.CustomInfo;
        }

    }


    public class CustomAppointment {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Subject { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public int Label { get; set; }
        public string Location { get; set; }
        public bool AllDay { get; set; }
        public int EventType { get; set; }
        public string RecurrenceInfo { get; set; }
        public string ReminderInfo { get; set; }
        public int Id { get; set; }
        public object ResourceId { get; set; }

        public string TimeZoneID { get; set; }

        public string CustomInfo { get; set; }
    }
}