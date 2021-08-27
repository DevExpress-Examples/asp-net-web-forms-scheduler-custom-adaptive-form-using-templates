<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/324958574/20.1.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T960823)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# ASPxScheduler - How to create a custom adaptive Appointment Form using templates (User Control)
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/324958574/)**
<!-- run online end -->

The ASPxScheduler controls supports two mechanisms to create a custom Appointment Form:

1. Using a custom View Model API:
[How to: Customize the Appointment Dialog using View Model API (working with custom fields)](https://docs.devexpress.com/AspNet/119731/aspnet-webforms-controls/scheduler/examples/customization/custom-form-and-custom-fields/how-to-customize-the-appointment-dialog-using-view-model-api-working-with-custom-fields)
2. Creating a custom User Control:
[How to: Customize the Appointment Editing Form for Working with Custom Fields](https://docs.devexpress.com/AspNet/5464/aspnet-webforms-controls/scheduler/examples/customization/custom-form-and-custom-fields/how-to-customize-the-appointment-editing-form-for-working-with-custom-fields)
If the 1st mechanism (View Model API) is used, a custom Appointment Form is adaptive by default.
In the case of using the 2nd approach, you need to create a built-in Popup Window.


This example demonstrates how to use the ASPxFormLayhout control in [responsive mode](https://demos.devexpress.com/ASPxNavigationAndLayoutDemos/FormLayout/ResponsiveLayout.aspx?device=phone&rotate=0) as the main form's container to make a custom Appointment Form adaptive.

<!-- default file list -->
*Files to look at*:

CS
* [AppointmentForm.ascx](./CS/WebApplication1/DevExpress/ASPxSchedulerForms/AppointmentForm.ascx)
* [AppointmentForm.ascx.cs](./CS/WebApplication1/DevExpress/ASPxSchedulerForms/AppointmentForm.ascx.cs)
* [CustomAppointmentSaveCallbackCommand.cs](./CS/WebApplication1/CustomCommands/CustomAppointmentSaveCallbackCommand.cs)

VB
* [AppointmentForm.ascx](./VB/WebApplication1/DevExpress/ASPxSchedulerForms/AppointmentForm.ascx)
* [AppointmentForm.ascx.vb](./VB/WebApplication1/DevExpress/ASPxSchedulerForms/AppointmentForm.ascx.vb)
* [CustomAppointmentSaveCallbackCommand.vb](./VB/WebApplication1/CustomCommands/CustomAppointmentSaveCallbackCommand.vb)
