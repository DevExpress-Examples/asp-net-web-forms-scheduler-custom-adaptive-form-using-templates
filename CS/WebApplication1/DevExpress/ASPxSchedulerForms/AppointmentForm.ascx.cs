using System;
using System.Web.UI;
using DevExpress.XtraScheduler;
using DevExpress.Web;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxScheduler.Internal;
using System.Collections;
using System.Collections.Generic;
using DevExpress.XtraScheduler.Localization;
using DevExpress.Web.ASPxScheduler.Localization;
using DevExpress.Utils;
using System.Web.UI.WebControls;
using DevExpress.Utils.Localization;
using DevExpress.Web.ASPxScheduler.Controls;

public partial class AppointmentForm : SchedulerFormControl {
    public override string ClassName { get { return "ASPxAppointmentForm"; } }

    public bool CanShowReminders {
        get {
            return ((AppointmentFormTemplateContainer)Parent).Control.Storage.EnableReminders;
        }
    }

    public bool ResourceSharing {
        get {
            return ((AppointmentFormTemplateContainer)Parent).Control.Storage.ResourceSharing;
        }
    }
    public IEnumerable ResourceDataSource {
        get {
            return ((AppointmentFormTemplateContainer)Parent).ResourceDataSource;
        }
    }

    public bool TimeZonesEnabled {
        get {
            return ((AppointmentFormTemplateContainer)Parent).TimeZonesEnabled;
        }
    }

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        Localize();
        tbSubject.Focus();
    }
    void Localize() {
        appointmentFormMainLayout.FindItemOrGroupByName("itemSubject").Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Subject);
        appointmentFormMainLayout.FindItemOrGroupByName("itemLocation").Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Location);
        appointmentFormMainLayout.FindItemOrGroupByName("itemLabel").Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Label);
        appointmentFormMainLayout.FindItemOrGroupByName("itemStart").Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_StartTime);
        appointmentFormMainLayout.FindItemOrGroupByName("itemEnd").Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_EndTime);

        appointmentFormMainLayout.FindItemOrGroupByName("itemStatus").Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Status);
        appointmentFormMainLayout.FindItemOrGroupByName("itemAllDay").Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_AllDayEvent);

        LayoutItemBase multipleResourceItem = appointmentFormMainLayout.FindItemOrGroupByName("itemResourceMultiple");
        LayoutItemBase singleResourceItem = appointmentFormMainLayout.FindItemOrGroupByName("itemResourceSingle");
        multipleResourceItem.Caption = singleResourceItem.Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Resource);
        multipleResourceItem.Visible = ResourceSharing;
        singleResourceItem.Visible = !ResourceSharing;

        LayoutItemBase reminderItem = appointmentFormMainLayout.FindItemOrGroupByName("itemReminder");
        reminderItem.Visible = CanShowReminders;
        reminderItem.Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Reminder);

        LayoutItemBase timeZoneItem = appointmentFormMainLayout.FindItemOrGroupByName("itemTimeZone");
        timeZoneItem.Visible = TimeZonesEnabled;
        timeZoneItem.Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_TimeZone);

        LayoutItemBase recInfoItem = appointmentFormMainLayout.FindItemOrGroupByName("itemRecurrenceInfo");
        recInfoItem.Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Recurrence);

        cbRecurrenceType.Items.Add(ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Caption_RecurrenceType_Daily), "Daily");
        cbRecurrenceType.Items.Add(ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Caption_RecurrenceType_Weekly), "Weekly");
        cbRecurrenceType.Items.Add(ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Caption_RecurrenceType_Monthly), "Monthly");
        cbRecurrenceType.Items.Add(ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Caption_RecurrenceType_Yearly), "Yearly");
        
        btnOk.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_ButtonOk);
        btnCancel.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_ButtonCancel);
        btnDelete.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_ButtonDelete);

        btnOk.Wrap = DefaultBoolean.False;
        btnCancel.Wrap = DefaultBoolean.False;
        btnDelete.Wrap = DefaultBoolean.False;
    }
    public override void DataBind() {
        base.DataBind();

        AppointmentFormTemplateContainer container = (AppointmentFormTemplateContainer)Parent;
        Appointment apt = container.Appointment;
        IAppointmentStorageBase appointmentStorage = container.Control.Storage.Appointments;
        IAppointmentLabel label = appointmentStorage.Labels.GetById(apt.LabelKey);
        IAppointmentStatus status = appointmentStorage.Statuses.GetById(apt.StatusKey);

        //SUBJECT
        tbSubject.Text = apt.Subject;

        //LOCATION
        tbLocation.Text = apt.Location;

        //LABEL
        edtLabel.ValueType = apt.LabelKey.GetType();
        edtLabel.SelectedIndex = appointmentStorage.Labels.IndexOf(label);
        edtLabel.DataSource = container.LabelDataSource;
        edtLabel.DataBindItems();

        //STATUS
        edtStatus.ValueType = apt.StatusKey.GetType();
        edtStatus.SelectedIndex = appointmentStorage.Statuses.IndexOf(status);
        edtStatus.DataSource = container.StatusDataSource;
        edtStatus.DataBindItems();

        //START
        edtStartDate.Date = apt.Start;
        edtStartTime.DateTime = apt.Start;

        //END
        edtEndDate.Date = apt.End;
        edtEndTime.DateTime = apt.End;

        //ALL DAY
        chkAllDay.Checked = apt.AllDay;

        //REMINDER
        cbReminder.ValueType = typeof(string);
        cbReminder.DataSource = container.ReminderDataSource;
        cbReminder.DataBindItems();
        cbReminder.Items.Insert(0, new ListEditItem("None", "None"));

        if(apt.HasReminder)
            cbReminder.Value = apt.Reminder.TimeBeforeStart.ToString();
        else
            cbReminder.SelectedIndex = 0;

        //DESCRIPTION
        tbDescription.Text = apt.Description;

        //RESOURCE
        PopulateResourceEditors(apt, container);

        //TIME ZONE
        if(TimeZonesEnabled) {
            cbTimeZone.DataSource = TimeZoneInfo.GetSystemTimeZones();
            cbTimeZone.ValueField = "Id";
            cbTimeZone.TextField = "DisplayName";
            cbTimeZone.DataBind();
            cbTimeZone.Value = container.TimeZoneId;
            cbTimeZone.Enabled = apt.Type == AppointmentType.Normal || apt.Type == AppointmentType.Pattern;
        }

        //RECCURRENCE
        PopulateRecurrenceFormEditors(container);

        schedulerStatusInfo.MasterControlID = container.Control.ID;

        //btnOk.ClientSideEvents.Click = container.SaveHandler;
        btnCancel.ClientSideEvents.Click = container.CancelHandler;
        btnDelete.ClientSideEvents.Click = container.DeleteHandler;
        JSProperties.Add("cpHasExceptions", apt.HasExceptions);
        btnDelete.Enabled = !container.IsNewAppointment;
    }

    private void PopulateRecurrenceFormEditors(AppointmentFormTemplateContainer container) {
        LayoutItemBase recInfoItem = appointmentFormMainLayout.FindItemOrGroupByName("itemRecurrenceInfo");
        LayoutItemBase recInfoTypeGroup = appointmentFormMainLayout.FindItemOrGroupByName("groupRecurrenceType");
        LayoutItemBase recInfoRangeGroup = appointmentFormMainLayout.FindItemOrGroupByName("groupRecurrenceRange");

        recInfoItem.Visible = container.ShouldShowRecurrence;
        recInfoTypeGroup.Visible = container.ShouldShowRecurrence;
        recInfoRangeGroup.Visible = container.ShouldShowRecurrence;

        if(container.IsRecurring) {
            chkRecurrence.Checked = true;
            recInfoTypeGroup.ClientVisible = true;
            recInfoRangeGroup.ClientVisible = true;

            cbRecurrenceType.Value = container.RecurrenceType.ToString();

            dailyControl.Periodicity = container.RecurrencePeriodicity;
            dailyControl.WeekDays = container.RecurrenceWeekDays;

            weeklyControl.Periodicity = container.RecurrencePeriodicity;
            weeklyControl.WeekDays = container.RecurrenceWeekDays;

            monthlyControl.DayNumber = container.RecurrenceDayNumber;
            monthlyControl.Periodicity = container.RecurrencePeriodicity;
            monthlyControl.Start = container.RecurrenceStart;
            monthlyControl.WeekDays = container.RecurrenceWeekDays;
            monthlyControl.WeekOfMonth = container.RecurrenceWeekOfMonth;

            yearlyControl.DayNumber = container.RecurrenceDayNumber;
            yearlyControl.Month = container.RecurrenceMonth;
            yearlyControl.Start = container.RecurrenceStart;
            yearlyControl.WeekDays = container.RecurrenceWeekDays;
            yearlyControl.WeekOfMonth = container.RecurrenceWeekOfMonth;

            rangeControl.OccurrenceCount = container.RecurrenceOccurrenceCount;
            rangeControl.Range = container.RecurrenceRange;
            rangeControl.End = container.RecurrenceEnd;
        }
        else {
            chkRecurrence.Checked = false;
            cbRecurrenceType.SelectedIndex = 0;
            recInfoTypeGroup.ClientVisible = false;
            recInfoRangeGroup.ClientVisible = false;
        }
    }

    private void PopulateResourceEditors(Appointment apt, AppointmentFormTemplateContainer container) {
        if(ResourceSharing) {
            ASPxListBox edtMultiResource = ddResource.FindControl("edtMultiResource") as ASPxListBox;
            edtMultiResource.DataSource = container.ResourceDataSource;
            edtMultiResource.DataBindItems();
            if(edtMultiResource == null)
                return;
            SetListBoxSelectedValues(edtMultiResource, apt.ResourceIds);
            List<String> multiResourceString = GetListBoxSelectedItemsText(edtMultiResource);
            string stringResourceNone = SchedulerLocalizer.GetString(SchedulerStringId.Caption_ResourceNone);
            ddResource.Value = stringResourceNone;
            if(multiResourceString.Count > 0)
                ddResource.Value = String.Join(", ", multiResourceString.ToArray());
            ddResource.JSProperties.Add("cp_Caption_ResourceNone", stringResourceNone);
        }
        else {
            edtResource.DataSource = container.ResourceDataSource;
            edtResource.DataBindItems();

            if(!Object.Equals(apt.ResourceId, EmptyResourceId.Id))
                edtResource.Value = apt.ResourceId.ToString();
            else
                edtResource.Value = SchedulerIdHelper.EmptyResourceId;
        }
    }
    List<String> GetListBoxSelectedItemsText(ASPxListBox listBox) {
        List<String> result = new List<string>();
        foreach(ListEditItem editItem in listBox.Items) {
            if(editItem.Selected)
                result.Add(editItem.Text);
        }
        return result;
    }
    void SetListBoxSelectedValues(ASPxListBox listBox, IEnumerable values) {
        listBox.Value = null;
        foreach(object value in values) {
            ListEditItem item = listBox.Items.FindByValue(value.ToString());
            if(item != null)
                item.Selected = true;
        }
    }
    protected override void PrepareChildControls() {
        AppointmentFormTemplateContainer container = (AppointmentFormTemplateContainer)Parent;
        ASPxScheduler control = container.Control;

        base.PrepareChildControls();
    }
    protected override ASPxEditBase[] GetChildEditors() {
        ASPxEditBase[] edits = new ASPxEditBase[] {
            tbSubject,
            chkAllDay,
            edtStartDate,
            edtEndDate,
            edtStartTime,
            edtEndTime,
            tbLocation,
            edtLabel,
            edtStatus,
            edtResource,
            GetMultiResourceEditor(),
            cbReminder,
            cbTimeZone,
            tbDescription,
            chkRecurrence,
            cbRecurrenceType,
        };


        return edits;
    }
    ASPxEditBase GetMultiResourceEditor() {
        if(ddResource != null)
            return ddResource.FindControl("edtMultiResource") as ASPxEditBase;
        return null;
    }
    protected override ASPxButton[] GetChildButtons() {
        ASPxButton[] buttons = new ASPxButton[] {
            btnOk, btnCancel, btnDelete
        };
        return buttons;
    }
    protected override Control[] GetChildControls() {
        return new Control[] { dailyControl, weeklyControl, monthlyControl, yearlyControl, rangeControl };
    }
    protected override WebControl GetDefaultButton() {
        return btnOk;
    }
    protected override void PrepareLocalization(SchedulerLocalizationCache localizationCache) {
        localizationCache.Add(SchedulerStringId.Msg_RecurrenceExceptionsWillBeLost);
        localizationCache.Add(SchedulerStringId.Msg_Warning);
    }
}
