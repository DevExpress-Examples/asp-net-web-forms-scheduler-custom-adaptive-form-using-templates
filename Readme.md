<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/324958574/20.1.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T960823)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Scheduler for ASP.NET Web Forms - How to create a custom adaptive appointment form using templates (User Control)
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/324958574/)**
<!-- run online end -->

This example demonstrates how to use the [ASPxFormLayout](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxFormLayout) component in responsive mode as the main form container to make a custom appointment form adaptive.

## Implementation Details

The [ASPxScheduler](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxScheduler.ASPxScheduler) control supports two approaches to create a custom appointment form.

* [Customize the Appointment Dialog using View Model API](https://docs.devexpress.com/AspNet/119731/components/scheduler/examples/customization/custom-form-and-custom-fields/how-to-customize-the-appointment-dialog-using-view-model-api-working-with-custom-fields). When you use this approach, custom appointment form is adaptive by default. 
* [Customize the Appointment Editing Form for Working with Custom Fields](https://docs.devexpress.com/AspNet/5464/components/scheduler/examples/customization/custom-form-and-custom-fields/how-to-customize-the-appointment-editing-form-for-working-with-custom-fields). When you use this approach, you should implement adaptivity of custom appointment form manually.

In this example, the custom appointment form contains [ASPxFormLayout](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxFormLayout) component. The [SettingsAdaptivity](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxFormLayout.SettingsAdaptivity) property is spesified to provide the form with responsive layout.

```aspx
<SettingsAdaptivity>
    <GridSettings WrapCaptionAtWidth="810">
        <Breakpoints>
            <dx:LayoutBreakpoint MaxWidth="810" ColumnCount="1" Name="S" />
        </Breakpoints>
    </GridSettings>
</SettingsAdaptivity>
```

## Files to Review

* [AppointmentForm.ascx](./CS/WebApplication1/DevExpress/ASPxSchedulerForms/AppointmentForm.ascx) (VB: [AppointmentForm.ascx](./VB/WebApplication1/DevExpress/ASPxSchedulerForms/AppointmentForm.ascx))
* [AppointmentForm.ascx.cs](./CS/WebApplication1/DevExpress/ASPxSchedulerForms/AppointmentForm.ascx.cs) (VB: [AppointmentForm.ascx.vb](./VB/WebApplication1/DevExpress/ASPxSchedulerForms/AppointmentForm.ascx.vb))
* [CustomAppointmentSaveCallbackCommand.cs](./CS/WebApplication1/CustomCommands/CustomAppointmentSaveCallbackCommand.cs) (VB: [CustomAppointmentSaveCallbackCommand.vb](./VB/WebApplication1/CustomCommands/CustomAppointmentSaveCallbackCommand.vb))

## Online Demo

* [Form Layout - Responsive Layout](https://demos.devexpress.com/ASPxNavigationAndLayoutDemos/FormLayout/ResponsiveLayout.aspx)
