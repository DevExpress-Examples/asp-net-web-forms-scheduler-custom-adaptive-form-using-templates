<%@ Control Language="vb" AutoEventWireup="true" Inherits="AppointmentForm" CodeBehind="AppointmentForm.ascx.vb" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.16.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v20.1, Version=20.1.16.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler.Controls" TagPrefix="dxsc" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v20.1, Version=20.1.16.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>

<dx:ASPxFormLayout ID="appointmentFormMainLayout" runat="server" AlignItemCaptionsInAllGroups="True" Width="100%" UseDefaultPaddings="true" ColumnCount="2" ClientInstanceName="mainFormLayout">
	<SettingsAdaptivity>
		<GridSettings WrapCaptionAtWidth="810">
			<Breakpoints>
				<dx:LayoutBreakpoint MaxWidth="810" ColumnCount="1" Name="S" />
			</Breakpoints>
		</GridSettings>
	</SettingsAdaptivity>
	<Items>
		<%--Subject--%>
		<dx:LayoutItem Name="itemSubject" ColumnSpan="2">
			<LayoutItemNestedControlCollection>
				<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
					<dx:ASPxTextBox ClientInstanceName="_dx" ID="tbSubject" runat="server" Width="100%" />
				</dx:LayoutItemNestedControlContainer>
			</LayoutItemNestedControlCollection>
		</dx:LayoutItem>

		<%--All Day, Start Date and End Date--%>
		<dx:LayoutGroup GroupBoxDecoration="None" ShowCaption="False" ColumnCount="6">
			<CellStyle Paddings-PaddingLeft="0" Paddings-PaddingRight="4" Paddings-PaddingBottom="0" Paddings-PaddingTop="0" />
			<GridSettings WrapCaptionAtWidth="810">
				<Breakpoints>
					<dx:LayoutBreakpoint MaxWidth="810" ColumnCount="2" Name="S" />
				</Breakpoints>
			</GridSettings>
			<Items>
				<dx:LayoutItem Name="itemAllDay" ColumnSpan="6">
					<SpanRules>
						<dx:SpanRule BreakpointName="S" ColumnSpan="2" />
					</SpanRules>
					<LayoutItemNestedControlCollection>
						<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
							<dx:ASPxCheckBox ClientInstanceName="_dx" ID="chkAllDay" runat="server" TextAlign="Right" ToggleSwitchDisplayMode="Always" />
						</dx:LayoutItemNestedControlContainer>
					</LayoutItemNestedControlCollection>
				</dx:LayoutItem>
				<dx:LayoutItem Name="itemStart" ColumnSpan="4">
					<SpanRules>
						<dx:SpanRule BreakpointName="S" ColumnSpan="1" />
					</SpanRules>
					<LayoutItemNestedControlCollection>
						<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
							<dx:ASPxDateEdit ID="edtStartDate" runat="server" Width="100%" EditFormat="Date" DateOnError="Undo" AllowNull="false" EnableClientSideAPI="true">
								<ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="false" EnableCustomValidation="True" Display="Dynamic"
									ValidationGroup="DateValidatoinGroup">
								</ValidationSettings>
							</dx:ASPxDateEdit>
						</dx:LayoutItemNestedControlContainer>
					</LayoutItemNestedControlCollection>
				</dx:LayoutItem>
				<dx:LayoutItem Name="itemStartTime" ShowCaption="False" ColumnSpan="2" VerticalAlign="Bottom">
					<SpanRules>
						<dx:SpanRule BreakpointName="S" ColumnSpan="1" />
					</SpanRules>
					<LayoutItemNestedControlCollection>
						<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
							<dx:ASPxTimeEdit ID="edtStartTime" runat="server" Width="100%" DateOnError="Undo" AllowNull="false" EnableClientSideAPI="true">
								<ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="false" EnableCustomValidation="True" Display="Dynamic"
									ValidationGroup="DateValidatoinGroup">
								</ValidationSettings>
							</dx:ASPxTimeEdit>
						</dx:LayoutItemNestedControlContainer>
					</LayoutItemNestedControlCollection>
				</dx:LayoutItem>
				<dx:LayoutItem Name="itemEnd" ColumnSpan="4">
					<SpanRules>
						<dx:SpanRule BreakpointName="S" ColumnSpan="1" />
					</SpanRules>
					<LayoutItemNestedControlCollection>
						<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
							<dx:ASPxDateEdit ID="edtEndDate" runat="server" EditFormat="Date" Width="100%" DateOnError="Undo" AllowNull="false" EnableClientSideAPI="true">
								<ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="false" EnableCustomValidation="True" Display="Dynamic"
									ValidationGroup="DateValidatoinGroup">
								</ValidationSettings>
							</dx:ASPxDateEdit>
						</dx:LayoutItemNestedControlContainer>
					</LayoutItemNestedControlCollection>
				</dx:LayoutItem>
				<dx:LayoutItem Name="itemEndTime" ShowCaption="False" ColumnSpan="2" VerticalAlign="Bottom">
					<SpanRules>
						<dx:SpanRule BreakpointName="S" ColumnSpan="1" />
					</SpanRules>
					<LayoutItemNestedControlCollection>
						<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
							<dx:ASPxTimeEdit ID="edtEndTime" runat="server" Width="100%" DateOnError="Undo" AllowNull="false" EnableClientSideAPI="true" HelpTextSettings-PopupMargins-MarginLeft="50">
								<ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="false" EnableCustomValidation="True" Display="Dynamic"
									ValidationGroup="DateValidatoinGroup">
								</ValidationSettings>
							</dx:ASPxTimeEdit>
						</dx:LayoutItemNestedControlContainer>
					</LayoutItemNestedControlCollection>
				</dx:LayoutItem>
			</Items>
		</dx:LayoutGroup>
		<%--Location, Label and Status--%>
		<dx:LayoutGroup GroupBoxDecoration="None" ShowCaption="False">
			<CellStyle Paddings-PaddingLeft="0" Paddings-PaddingRight="0" Paddings-PaddingBottom="0" Paddings-PaddingTop="0" />
			<GridSettings WrapCaptionAtWidth="810">
				<Breakpoints>
					<dx:LayoutBreakpoint MaxWidth="810" ColumnCount="1" Name="S" />
				</Breakpoints>
			</GridSettings>
			<Items>
				<dx:LayoutItem Name="itemLocation">
					<LayoutItemNestedControlCollection>
						<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
							<dx:ASPxTextBox ClientInstanceName="_dx" ID="tbLocation" runat="server" Width="100%" />
						</dx:LayoutItemNestedControlContainer>
					</LayoutItemNestedControlCollection>
				</dx:LayoutItem>
				<dx:LayoutItem Name="itemLabel">
					<SpanRules>
						<dx:SpanRule BreakpointName="S" ColumnSpan="1" />
					</SpanRules>
					<LayoutItemNestedControlCollection>
						<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
							<dx:ASPxComboBox ClientInstanceName="_dx" ID="edtLabel" runat="server" Width="100%" />
						</dx:LayoutItemNestedControlContainer>
					</LayoutItemNestedControlCollection>
				</dx:LayoutItem>
				<dx:LayoutItem Name="itemStatus">
					<SpanRules>
						<dx:SpanRule BreakpointName="S" ColumnSpan="1" />
					</SpanRules>
					<LayoutItemNestedControlCollection>
						<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
							<dx:ASPxComboBox ClientInstanceName="_dx" ID="edtStatus" runat="server" Width="100%" />
						</dx:LayoutItemNestedControlContainer>
					</LayoutItemNestedControlCollection>
				</dx:LayoutItem>
			</Items>
		</dx:LayoutGroup>

		<%--Resources--%>
		<dx:LayoutItem Name="itemResourceSingle" ColumnSpan="2">
			<LayoutItemNestedControlCollection>
				<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
					<dx:ASPxComboBox ClientInstanceName="_dx" ID="edtResource" runat="server" Width="100%" />
				</dx:LayoutItemNestedControlContainer>
			</LayoutItemNestedControlCollection>
		</dx:LayoutItem>
		<dx:LayoutItem Name="itemResourceMultiple" ColumnSpan="2">
			<LayoutItemNestedControlCollection>
				<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
					<dx:ASPxDropDownEdit ID="ddResource" runat="server" Width="100%" ClientInstanceName="ddResource" AllowUserInput="false">
						<DropDownWindowTemplate>
							<dx:ASPxListBox ID="edtMultiResource" runat="server" Width="100%" SelectionMode="CheckColumn" Border-BorderWidth="0" />
						</DropDownWindowTemplate>
					</dx:ASPxDropDownEdit>
				</dx:LayoutItemNestedControlContainer>
			</LayoutItemNestedControlCollection>
		</dx:LayoutItem>

		<%--Reminder--%>
		<dx:LayoutItem Name="itemReminder">
			<LayoutItemNestedControlCollection>
				<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
					<dx:ASPxComboBox ID="cbReminder" runat="server" Width="100%" />
				</dx:LayoutItemNestedControlContainer>
			</LayoutItemNestedControlCollection>
		</dx:LayoutItem>

		<%--Time Zone Editor--%>
		<dx:LayoutItem Name="itemTimeZone">
			<LayoutItemNestedControlCollection>
				<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
					<dx:ASPxComboBox ClientInstanceName="_dx" ID="cbTimeZone" runat="server" Width="100%" />
				</dx:LayoutItemNestedControlContainer>
			</LayoutItemNestedControlCollection>
		</dx:LayoutItem>

		<%--Description--%>
		<dx:LayoutItem Name="itemDescription" ShowCaption="False" ColumnSpan="2">
			<LayoutItemNestedControlCollection>
				<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
					<dx:ASPxMemo ClientInstanceName="_dx" ID="tbDescription" runat="server" Width="100%" Rows="5" />
				</dx:LayoutItemNestedControlContainer>
			</LayoutItemNestedControlCollection>
		</dx:LayoutItem>

		<%--Recurrence Info Check Box--%>
		<dx:LayoutItem Name="itemRecurrenceInfo" ColumnSpan="1" Caption="Recurrence">
			<LayoutItemNestedControlCollection>
				<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
					<dx:ASPxCheckBox ClientInstanceName="_dx" ID="chkRecurrence" runat="server" TextAlign="Right" ToggleSwitchDisplayMode="Always">
						<ClientSideEvents CheckedChanged="function (s, e) { 
							mainFormLayout.GetItemByName('groupRecurrenceRange').SetVisible(s.GetChecked());  
							mainFormLayout.GetItemByName('groupRecurrenceType').SetVisible(s.GetChecked());                             
						}" />
					</dx:ASPxCheckBox>
				</dx:LayoutItemNestedControlContainer>
			</LayoutItemNestedControlCollection>
		</dx:LayoutItem>

		<dx:LayoutGroup GroupBoxDecoration="None" ShowCaption="False" ColumnSpan="2" ColumnCount="3" Name="groupRecurrenceMain" ClientVisible="true" AlignItemCaptions="false">
			<CellStyle Paddings-PaddingLeft="0" Paddings-PaddingRight="0" Paddings-PaddingBottom="0" Paddings-PaddingTop="0" />
			<GridSettings WrapCaptionAtWidth="810">
				<Breakpoints>
					<dx:LayoutBreakpoint MaxWidth="810" ColumnCount="1" Name="S" />
				</Breakpoints>
			</GridSettings>
			<Items>


				<%--Recurrence Info Type--%>
				<dx:LayoutGroup GroupBoxDecoration="None" ShowCaption="False" ColumnSpan="2" Name="groupRecurrenceType" ClientVisible="false">
					<CellStyle Paddings-PaddingLeft="0" Paddings-PaddingRight="0" Paddings-PaddingBottom="0" Paddings-PaddingTop="0" />
					<GridSettings WrapCaptionAtWidth="810">
						<Breakpoints>
							<dx:LayoutBreakpoint MaxWidth="810" ColumnCount="1" Name="S" />
						</Breakpoints>
					</GridSettings>
					<Items>
						<dx:LayoutItem Name="itemType" ShowCaption="False">
							<LayoutItemNestedControlCollection>
								<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
									<dx:ASPxComboBox ClientInstanceName="_dx" ID="cbRecurrenceType" runat="server" Width="80%">
										<ClientSideEvents SelectedIndexChanged="function (s, e) { 
									mainFormLayout.GetItemByName('itemDaily').SetVisible(s.GetValue() == 'Daily');
									mainFormLayout.GetItemByName('itemWeekly').SetVisible(s.GetValue() == 'Weekly');
									mainFormLayout.GetItemByName('itemMonthly').SetVisible(s.GetValue() == 'Monthly');
									mainFormLayout.GetItemByName('itemYearly').SetVisible(s.GetValue() == 'Yearly');
								}" />
									</dx:ASPxComboBox>
								</dx:LayoutItemNestedControlContainer>
							</LayoutItemNestedControlCollection>
						</dx:LayoutItem>
						<dx:LayoutItem Name="itemDaily" ShowCaption="False">
							<LayoutItemNestedControlCollection>
								<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
									<dxsc:DailyRecurrenceControl runat="server" ID="dailyControl" ClientInstanceName="clientDailyControl" />
								</dx:LayoutItemNestedControlContainer>
							</LayoutItemNestedControlCollection>
						</dx:LayoutItem>
						<dx:LayoutItem Name="itemWeekly" ShowCaption="False" ClientVisible="false">
							<LayoutItemNestedControlCollection>
								<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
									<dxsc:WeeklyRecurrenceControl runat="server" ID="weeklyControl" ClientInstanceName="clientWeeklyControl" />
								</dx:LayoutItemNestedControlContainer>
							</LayoutItemNestedControlCollection>
						</dx:LayoutItem>
						<dx:LayoutItem Name="itemMonthly" ShowCaption="False" ClientVisible="false">
							<LayoutItemNestedControlCollection>
								<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
									<dxsc:MonthlyRecurrenceControl runat="server" ID="monthlyControl" ClientInstanceName="clientMonthlyControl" />
								</dx:LayoutItemNestedControlContainer>
							</LayoutItemNestedControlCollection>
						</dx:LayoutItem>
						<dx:LayoutItem Name="itemYearly" ShowCaption="False" ClientVisible="false">
							<LayoutItemNestedControlCollection>
								<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
									<dxsc:YearlyRecurrenceControl runat="server" ID="yearlyControl" ClientInstanceName="clientYearlyControl" />
								</dx:LayoutItemNestedControlContainer>
							</LayoutItemNestedControlCollection>
						</dx:LayoutItem>
					</Items>
				</dx:LayoutGroup>

				<%--Recurrence Info Range--%>
				<dx:LayoutGroup GroupBoxDecoration="None" ShowCaption="False" ColumnSpan="1" Name="groupRecurrenceRange" ClientVisible="false">
					<CellStyle Paddings-PaddingLeft="0" Paddings-PaddingRight="0" Paddings-PaddingBottom="0" Paddings-PaddingTop="0" />
					<GridSettings WrapCaptionAtWidth="810">
						<Breakpoints>
							<dx:LayoutBreakpoint MaxWidth="810" ColumnCount="1" Name="S" />
						</Breakpoints>
					</GridSettings>
					<Items>
						<dx:LayoutItem Name="itemRecurrenceRange" ShowCaption="False">
							<LayoutItemNestedControlCollection>
								<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
									<dxsc:RecurrenceRangeControl runat="server" ID="rangeControl" ClientInstanceName="clientRangeControl" />
								</dx:LayoutItemNestedControlContainer>
							</LayoutItemNestedControlCollection>
						</dx:LayoutItem>
					</Items>
				</dx:LayoutGroup>

			</Items>
		</dx:LayoutGroup>

		<dx:LayoutGroup Caption="" GroupBoxDecoration="HeadingLine" ColumnCount="3" ColumnSpan="2" HorizontalAlign="Center">
			<Items>
				<dx:LayoutItem ShowCaption="False" HorizontalAlign="Center">
					<LayoutItemNestedControlCollection>
						<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
							<dx:ASPxButton runat="server" ID="btnOk" UseSubmitBehavior="false" AutoPostBack="false"
								EnableViewState="false" Width="91px" EnableClientSideAPI="true" />
						</dx:LayoutItemNestedControlContainer>
					</LayoutItemNestedControlCollection>
				</dx:LayoutItem>
				<dx:LayoutItem ShowCaption="False" HorizontalAlign="Center">
					<LayoutItemNestedControlCollection>
						<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
							<dx:ASPxButton runat="server" ID="btnCancel" UseSubmitBehavior="false" AutoPostBack="false" EnableViewState="false"
								Width="91px" CausesValidation="False" EnableClientSideAPI="true" />
						</dx:LayoutItemNestedControlContainer>
					</LayoutItemNestedControlCollection>
				</dx:LayoutItem>
				<dx:LayoutItem ShowCaption="False" HorizontalAlign="Center">
					<LayoutItemNestedControlCollection>
						<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
							<dx:ASPxButton runat="server" ID="btnDelete" UseSubmitBehavior="false" AutoPostBack="false" EnableViewState="false"
								Width="91px" CausesValidation="False" EnableClientSideAPI="true" />
						</dx:LayoutItemNestedControlContainer>
					</LayoutItemNestedControlCollection>
				</dx:LayoutItem>
			</Items>
		</dx:LayoutGroup>
		<dx:LayoutGroup Caption="" GroupBoxDecoration="None" ColumnSpan="2" HorizontalAlign="Center">
			<Items>
				<dx:LayoutItem ShowCaption="False" HorizontalAlign="Center">
					<LayoutItemNestedControlCollection>
						<dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
							<dxsc:ASPxSchedulerStatusInfo runat="server" ID="schedulerStatusInfo" Priority="1" />
						</dx:LayoutItemNestedControlContainer>
					</LayoutItemNestedControlCollection>
				</dx:LayoutItem>
			</Items>
		</dx:LayoutGroup>
	</Items>
</dx:ASPxFormLayout>

<script id="dxss_ASPxSchedulerAppoinmentForm" type="text/javascript">
	ASPxAppointmentForm = ASPx.CreateClass(ASPxClientFormBase, {
		Initialize: function () {
			this.isValid = true;
			this.controls.edtStartDate.Validation.AddHandler(ASPx.CreateDelegate(this.OnEdtStartDateValidate, this));
			this.controls.edtEndDate.Validation.AddHandler(ASPx.CreateDelegate(this.OnEdtEndDateValidate, this));
			this.controls.edtStartDate.ValueChanged.AddHandler(ASPx.CreateDelegate(this.OnUpdateStartDateTimeValue, this));
			this.controls.edtEndDate.ValueChanged.AddHandler(ASPx.CreateDelegate(this.OnUpdateEndDateTimeValue, this));
			this.controls.edtStartTime.ValueChanged.AddHandler(ASPx.CreateDelegate(this.OnUpdateStartDateTimeValue, this));
			this.controls.edtEndTime.ValueChanged.AddHandler(ASPx.CreateDelegate(this.OnUpdateEndDateTimeValue, this));
			this.controls.chkAllDay.CheckedChanged.AddHandler(ASPx.CreateDelegate(this.OnChkAllDayCheckedChanged, this));
			this.controls.btnOk.Click.AddHandler(ASPx.CreateDelegate(this.OnBtnOk, this));

			this.UpdateTimeEditorsVisibility();

			if (this.controls.edtMultiResource)
				this.controls.edtMultiResource.SelectedIndexChanged.AddHandler(ASPx.CreateDelegate(this.OnEdtMultiResourceSelectedIndexChanged, this));
			var start = this.controls.edtStartDate.GetValue();
			var end = this.controls.edtEndDate.GetValue();
			var duration = ASPxClientTimeInterval.CalculateDuration(start, end);
			this.appointmentInterval = new ASPxClientTimeInterval(start, duration);
			this.appointmentInterval.SetAllDay(this.controls.chkAllDay.GetValue());
			this.primaryIntervalJson = ASPx.Json.ToJson(this.appointmentInterval);
			this.UpdateDateTimeEditors();

			this.primaryRecurrenceInfo = this.controls.chkRecurrence ? this.GetRecurrenceInfo() : "";
		},
		GetRecurrenceInfo: function () {
			var recType = this.controls.cbRecurrenceType.GetValue();
			var dailyInfo = ASPx.Json.ToJson(this.controls.dailyControl.GetValue());
			var weeklyInfo = ASPx.Json.ToJson(this.controls.weeklyControl.GetValue());
			var monthlyInfo = ASPx.Json.ToJson(this.controls.monthlyControl.GetValue());
			var yearlyInfo = ASPx.Json.ToJson(this.controls.yearlyControl.GetValue());
			var recRange = ASPx.Json.ToJson(this.controls.rangeControl.GetValue());

			return recType + "|" + dailyInfo + "|" + weeklyInfo + "|" + monthlyInfo + "|" + yearlyInfo + "|" + recRange;
		},
		OnBtnOk: function (s, e) {
			e.processOnServer = false;
			var formOwner = this.GetFormOwner();
			if (!formOwner)
				return;
			if (this.controls.chkRecurrence && this.IsRecurrenceChainRecreationNeeded() && this.cpHasExceptions) {
				formOwner.ShowMessageBox(this.localization.SchedulerLocalizer.Msg_Warning, this.localization.SchedulerLocalizer.Msg_RecurrenceExceptionsWillBeLost, this.OnWarningExceptionWillBeLostOk.aspxBind(this));
			} else {
				formOwner.AppointmentFormSave();
			}
		},
		IsRecurrenceChainRecreationNeeded: function () {
			var isIntervalChanged = this.primaryIntervalJson != ASPx.Json.ToJson(this.appointmentInterval);
			var currentRecInfo = this.GetRecurrenceInfo();
			return isIntervalChanged || (this.primaryRecurrenceInfo != currentRecInfo);
		},
		OnWarningExceptionWillBeLostOk: function () {
			this.GetFormOwner().AppointmentFormSave();
		},
		OnEdtMultiResourceSelectedIndexChanged: function (s, e) {
			var resourceNames = new Array();
			var items = s.GetSelectedItems();
			var count = items.length;
			if (count > 0) {
				for (var i = 0; i < count; i++)
					resourceNames.push(items[i].text);
			}
			else
				resourceNames.push(ddResource.cp_Caption_ResourceNone);
			ddResource.SetValue(resourceNames.join(', '));
		},
		OnEdtStartDateValidate: function (s, e) {
			if (!e.isValid)
				return;
			var startDate = this.controls.edtStartDate.GetDate();
			var endDate = this.controls.edtEndDate.GetDate();
			e.isValid = startDate == null || endDate == null || startDate <= endDate;
			e.errorText = "The Start Date must precede the End Date.";
		},
		OnEdtEndDateValidate: function (s, e) {
			if (!e.isValid)
				return;
			var startDate = this.controls.edtStartDate.GetDate();
			var endDate = this.controls.edtEndDate.GetDate();
			e.isValid = startDate == null || endDate == null || startDate <= endDate;
			e.errorText = "The Start Date must precede the End Date.";
		},
		OnUpdateEndDateTimeValue: function (s, e) {
			var isAllDay = this.controls.chkAllDay.GetValue();
			var date = ASPxSchedulerDateTimeHelper.TruncToDate(this.controls.edtEndDate.GetDate());
			if (isAllDay)
				date = ASPxSchedulerDateTimeHelper.AddDays(date, 1);
			var time = ASPxSchedulerDateTimeHelper.ToDayTime(this.controls.edtEndTime.GetDate());
			var dateTime = ASPxSchedulerDateTimeHelper.AddTimeSpan(date, time);
			this.appointmentInterval.SetEnd(dateTime);
			this.UpdateDateTimeEditors();
			this.Validate();
		},
		OnUpdateStartDateTimeValue: function (s, e) {
			var date = ASPxSchedulerDateTimeHelper.TruncToDate(this.controls.edtStartDate.GetDate());
			var time = ASPxSchedulerDateTimeHelper.ToDayTime(this.controls.edtStartTime.GetDate());
			var dateTime = ASPxSchedulerDateTimeHelper.AddTimeSpan(date, time);
			this.appointmentInterval.SetStart(dateTime);
			this.UpdateDateTimeEditors();
			if (this.controls.AppointmentRecurrenceForm1)
				this.controls.AppointmentRecurrenceForm1.SetStart(dateTime);
			this.Validate();
		},
		OnChkAllDayCheckedChanged: function (s, e) {
			this.UpdateTimeEditorsVisibility();
			var isAllDay = this.controls.chkAllDay.GetValue();
			this.appointmentInterval.SetAllDay(isAllDay);
			this.UpdateDateTimeEditors();
		},
		UpdateDateTimeEditors: function () {
			var isAllDay = this.controls.chkAllDay.GetValue();
			this.controls.edtStartDate.SetValue(this.appointmentInterval.GetStart());
			var end = this.appointmentInterval.GetEnd();
			if (isAllDay) {
				end = ASPxSchedulerDateTimeHelper.AddDays(end, -1);
			}
			this.controls.edtEndDate.SetValue(end);
			this.controls.edtStartTime.SetValue(this.appointmentInterval.GetStart());
			this.controls.edtEndTime.SetValue(end);
		},
		UpdateTimeEditorsVisibility: function () {
			var isAllDay = this.controls.chkAllDay.GetValue();

			this.controls.edtEndTime.SetEnabled(!isAllDay);
			this.controls.edtStartTime.SetEnabled(!isAllDay);
		},
		Validate: function () {
			this.isValid = ASPxClientEdit.ValidateEditorsInContainer(null);
			this.controls.btnOk.SetEnabled(this.isValid);
		}
	});
</script>