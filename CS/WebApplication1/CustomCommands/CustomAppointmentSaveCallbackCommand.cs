using DevExpress.Web;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxScheduler.Controls;
using DevExpress.Web.ASPxScheduler.Internal;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.CustomCommands {
    public class CustomAppointmentSaveCallbackCommand : AppointmentFormSaveCallbackCommand {
        public CustomAppointmentSaveCallbackCommand(ASPxScheduler control) : base(control) { }

        protected override void AssignControllerValues() {
            base.AssignControllerValues();
        }
        protected override bool ShouldShowRecurrence() {
            ASPxCheckBox chkRecurrence = FindControlByID("chkRecurrence") as ASPxCheckBox;
            if(chkRecurrence != null) {
                return chkRecurrence.Checked;
            }
            return base.ShouldShowRecurrence();
        }
        protected override void AssignControllerRecurrenceValues(DateTime clientStart) {
            //base.AssignControllerRecurrenceValues(clientStart);
            if(ShouldShowRecurrence()) {

                Appointment patternCopy = Controller.PrepareToRecurrenceEdit();
                IRecurrenceInfo rinfo = patternCopy.RecurrenceInfo;

                ASPxComboBox cbRecurrenceType = FindControlByID("cbRecurrenceType") as ASPxComboBox;
                DailyRecurrenceControl dailyControl = FindControlByID("dailyControl") as DailyRecurrenceControl;
                WeeklyRecurrenceControl weeklyControl = FindControlByID("weeklyControl") as WeeklyRecurrenceControl;
                MonthlyRecurrenceControl monthlyControl = FindControlByID("monthlyControl") as MonthlyRecurrenceControl;
                YearlyRecurrenceControl yearlyControl = FindControlByID("yearlyControl") as YearlyRecurrenceControl;

                RecurrenceRangeControl rangeControl = FindControlByID("rangeControl") as RecurrenceRangeControl;

                switch(cbRecurrenceType.Value) {
                    case "Daily":
                        rinfo.Type = DevExpress.XtraScheduler.RecurrenceType.Daily;
                        rinfo.Periodicity = dailyControl.ClientPeriodicity;
                        rinfo.WeekDays = dailyControl.ClientWeekDays;
                        break;
                    case "Weekly":
                        rinfo.Type = DevExpress.XtraScheduler.RecurrenceType.Weekly;
                        rinfo.Periodicity = weeklyControl.ClientPeriodicity;
                        rinfo.WeekDays = weeklyControl.ClientWeekDays;
                        break;
                    case "Monthly":
                        rinfo.Type = DevExpress.XtraScheduler.RecurrenceType.Monthly;
                        rinfo.DayNumber = monthlyControl.ClientDayNumber;
                        rinfo.Periodicity = monthlyControl.ClientPeriodicity;
                        rinfo.WeekDays = monthlyControl.ClientWeekDays;                        
                        rinfo.WeekOfMonth = monthlyControl.ClientWeekOfMonth;
                        break;
                    case "Yearly":
                        rinfo.Type = DevExpress.XtraScheduler.RecurrenceType.Yearly;
                        rinfo.DayNumber = yearlyControl.ClientDayNumber;
                        rinfo.Month = yearlyControl.ClientMonth;
                        rinfo.WeekDays = yearlyControl.ClientWeekDays;
                        rinfo.WeekOfMonth = yearlyControl.ClientWeekOfMonth;
                        break;
                    default:
                        break;
                }

                DateTime end = rangeControl.ClientEnd;
                if(!patternCopy.AllDay && Control.TimeZoneHelper != null)
                    end = Control.TimeZoneHelper.FromClientTime(end);
                ((IInternalRecurrenceInfo)rinfo).UpdateRange(clientStart, end, rangeControl.ClientRange, rangeControl.ClientOccurrenceCount, patternCopy);

                Controller.ApplyRecurrence(patternCopy);
            }            
        }

        protected override System.Web.UI.Control FindControlByID(string id) {
            return FindTemplateControl(TemplateContainer, id);
        }

        System.Web.UI.Control FindTemplateControl(System.Web.UI.Control RootControl, string id) {
            System.Web.UI.Control foundedControl = RootControl.FindControl(id);
            if(foundedControl == null) {
                foreach(System.Web.UI.Control item in RootControl.Controls) {
                    foundedControl = FindTemplateControl(item, id);
                    if(foundedControl != null) break;
                }
            }
            return foundedControl;
        }
    }
}