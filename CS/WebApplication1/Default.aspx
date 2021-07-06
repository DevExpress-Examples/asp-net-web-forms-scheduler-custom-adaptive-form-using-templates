<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v20.1, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.XtraScheduler.v20.1.Core, Version=20.1.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraScheduler" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server" AppointmentDataSourceID="ObjectDataSourceAppointment"
                ResourceDataSourceID="ObjectDataSourceResources" ClientIDMode="AutoID" Start='<%# DateTime.Now %>' GroupType="Date" ClientInstanceName="clientScheduler"
                OnPrepareAppointmentFormPopupContainer="ASPxScheduler1_PrepareAppointmentFormPopupContainer" 
                OnBeforeExecuteCallbackCommand="ASPxScheduler1_BeforeExecuteCallbackCommand">
                <OptionsForms AppointmentFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/AppointmentForm.ascx" />
                <Storage EnableReminders="true" EnableTimeZones="true">
                    <Appointments AutoRetrieveId="true" ResourceSharing="false">
                        <Mappings AppointmentId="Id" Start="StartTime" End="EndTime" Subject="Subject" AllDay="AllDay"
                            Description="Description" Label="Label" Location="Location" RecurrenceInfo="RecurrenceInfo"
                            Status="Status" Type="EventType" ResourceId="ResourceId" TimeZoneId="TimeZoneID" />
                        <CustomFieldMappings>
                            <dxwschs:ASPxAppointmentCustomFieldMapping Member="CustomInfo" Name="ApptCustomInfo" ValueType="String" />
                        </CustomFieldMappings>
                    </Appointments>
                    <Resources>
                        <Mappings ResourceId="ResourceId" Caption="Caption" />
                    </Resources>
                </Storage>
                <Views>
                    <DayView>
                        <TimeRulers>
                            <cc1:TimeRuler AlwaysShowTimeDesignator="False" ShowCurrentTime="Never"></cc1:TimeRuler>
                        </TimeRulers>

                        <AppointmentDisplayOptions ColumnPadding-Left="2" ColumnPadding-Right="4"></AppointmentDisplayOptions>

                        <DayViewStyles ScrollAreaHeight="600px">
                        </DayViewStyles>
                    </DayView>

                    <WorkWeekView>
                        <TimeRulers>
                            <cc1:TimeRuler></cc1:TimeRuler>
                        </TimeRulers>

                        <AppointmentDisplayOptions ColumnPadding-Left="2" ColumnPadding-Right="4"></AppointmentDisplayOptions>
                    </WorkWeekView>

                    <WeekView ViewSelectorItemAdaptivePriority="4"></WeekView>

                    <MonthView ViewSelectorItemAdaptivePriority="5"></MonthView>

                    <TimelineView>
                        <AppointmentDisplayOptions StatusDisplayType="Bounds" />
                    </TimelineView>

                    <FullWeekView>
                        <TimeRulers>
                            <cc1:TimeRuler></cc1:TimeRuler>
                        </TimeRulers>

                        <AppointmentDisplayOptions ColumnPadding-Left="2" ColumnPadding-Right="4"></AppointmentDisplayOptions>
                    </FullWeekView>

                    <AgendaView ViewSelectorItemAdaptivePriority="1"></AgendaView>
                </Views>
            </dxwschs:ASPxScheduler>

            <asp:ObjectDataSource ID="ObjectDataSourceResources" runat="server" SelectMethod="GetCustomResources" TypeName="WebApplication1.Helpers.ResourceDataSourceHelper"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSourceAppointment" runat="server" DataObjectTypeName="WebApplication1.Helpers.CustomAppointment" DeleteMethod="DeleteCustomAppointment" InsertMethod="InsertCustomAppointment" SelectMethod="GetCustomAppointmentsList" TypeName="WebApplication1.Helpers.AppointmentDataSourceHelper" UpdateMethod="UpdateCustomAppointment"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
