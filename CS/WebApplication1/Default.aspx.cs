using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.Web.ASPxScheduler;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.iCalendar;
using WebApplication1.CustomCommands;
using WebApplication1.Helpers;

namespace WebApplication1 {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Init(object sender, EventArgs e) {            

        }

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void ASPxScheduler1_PrepareAppointmentFormPopupContainer(object sender, ASPxSchedulerPrepareFormPopupContainerEventArgs e) {
            e.Popup.SettingsAdaptivity.Mode = PopupControlAdaptivityMode.Always;
            e.Popup.SettingsAdaptivity.MaxWidth = Unit.Pixel(900);
            e.Popup.SettingsAdaptivity.VerticalAlign = PopupAdaptiveVerticalAlign.WindowCenter;
            e.Popup.SettingsAdaptivity.MinWidth = Unit.Pixel(570);
        }
        protected void ASPxScheduler1_BeforeExecuteCallbackCommand(object sender, SchedulerCallbackCommandEventArgs e) {
            if(e.CommandId == SchedulerCallbackCommandId.AppointmentSave) {
                e.Command = new CustomAppointmentSaveCallbackCommand((ASPxScheduler)sender);
            }
        }
    }
}