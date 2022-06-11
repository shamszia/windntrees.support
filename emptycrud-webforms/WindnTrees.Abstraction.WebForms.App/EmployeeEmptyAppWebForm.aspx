<%@ Page Title="Employee Empty Page"  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeEmptyAppWebForm.aspx.cs" Inherits="WindnTrees.Abstraction.WebForms.App.EmployeeEmptyAppWebForm" %>

<asp:Content ID="Templates" ContentPlaceHolderID="ContentPlaceTemplates" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>WindnTrees EmptyCRUD2EmptyCRUD Example</h3>

    <section id="observer-object-section" data-bind="with: getObserverObject()">
        <section class="observer-section">
            <div class="card">
                <div class="card-header">
                    <span data-bind="visible: getProcessing()"><i class="fa fa-cog fa-spin fa-2x"></i></span>
                    <span data-bind="if: getResultMessage().length > 0"><span data-bind="text: getResultMessage()"></span></span>
                    <div data-bind="if: getErrors().length > 0">
                        <ul class="errorlist" data-bind="foreach: { data: getObservableErrors(), as: 'error' }">
                            <li class="alert"><span data-bind="text: errField"></span><span data-bind="text: errMessage"></span></li>
                        </ul>
                    </div>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <div class="bootstrap-table">
                            <div class="fixed-table-toolbar">
                                <div class="form-group">
                                    <div class="input-group">
                                        <span class="input-group-prepend">
                                            <button class="btn btn-sm btn-primary" type="button" data-bind="click: function (data, event) { emptyCreate(); }" >new</button>
                                        </span>
                                        <input class="form-control col-12" data-bind="value: getObservableKeyword()" type="text" placeholder="keyword" />
                                        <span class="input-group-append">
                                            <button class="btn btn-sm btn-primary" type="button" data-bind="click: function (data, event) { emptyList(); }">find / load</button>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="fixed-table-container">
                                <div class="fixed-table-header"></div>
                                <div class="fixed-table-body">
                                    <table class="table table-hover grid-style-0">
                                        <tr>
                                            <th class="col-2">
                                                <span title="id">Id</span>
                                            </th>
                                            <th class="col-3">
                                                <span title="name">Name</span>
                                            </th>
                                            <th class="col-3">
                                                <span title="designation">Designation</span>
                                            </th>
                                            <th class="col-2">
                                                <span title="salary">Salary</span>
                                            </th>
                                            <th class="col-2"></th>
                                        </tr>
                                        <tbody data-bind="foreach: { data: getObservableRecords(), as: 'record' }">
                                            <tr>
                                                <td data-bind="text: Id()"></td>
                                                <td data-bind="text: Name()"></td>
                                                <td data-bind="text: Designation()"></td>
                                                <td data-bind="text: Salary()"></td>
                                                <td>
                                                    <span class="d-flex justify-content-end">
                                                        <a class="green p-1" href="#" title="edit" data-bind="click: function (data, event) { $parents[0].emptyUpdate(); }"><i class="fa fa-edit text-success"></i><span>edit </span></a>
                                                        <a class="red p-1" href="#" title="delete" data-bind="click: function (data, event) { $parents[0].emptyDelete(); }"><i class="fa fa-times text-danger"></i><span>delete </span></a>
                                                    </span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="form-group form-row">
                        <div class="col-6 order-0">
                            <div class="input-group justify-content-start">
                                <span class="input-group-prepend">
                                    <span class="input-group-text">List Size</span>
                                </span>
                                <select class="form-control col-2" data-bind="value: getObservableListSize(), event: { change: function () { $parents[0].fillRecords(1); } }" style="width: auto;">
                                    <option value="10">10</option>
                                    <option value="20">20</option>
                                    <option value="50">50</option>
                                    <option value="100">100</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-6 order-1">
                            <div class="input-group justify-content-end" data-bind="if: getListNavigator().calculateTotalPages() > 1">
                                <span class="input-group-prepend" data-bind="css: { disabled: getCurrentList() === 1 }"><a href="#" data-bind="click: function () { if (getCurrentList() > 1) { find(getCurrentList() - 1); } }"><span class="input-group-text">prev</span></a></span>
                                <span class="input-group-append" data-bind="css: { disabled: getCurrentList() === getListNavigator().calculateTotalPages() }"><a href="#" data-bind="click: function () { if (getCurrentList() < getListNavigator().calculateTotalPages()) { find(getCurrentList() + 1); } }"><span class="input-group-text">next</span></a></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <button class="btn btn-default" type="button" data-bind="click: function (data, event) { displayProcessingActivity(); }">Display Processing Activity</button>
                <button class="btn btn-default" type="button" data-bind="click: function (data, event) { displayClearActivity(); }">Display Clear Activity</button>
                <button class="btn btn-default" type="button" data-bind="click: function (data, event) { clearListRecordsView(); }">Clear Records</button>
            </div>
        </section>
    </section>
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ContentPlaceScript" runat="server">
    <script src="Scripts/knockout-3.5.1.js"></script>
    <script src="Scripts/knockout.validation.js"></script>

    <script src="Scripts/windntrees-131.min.js"></script>
    <script src="Scripts/Model/Employee.js"></script>

    <script type="text/javascript">

        //Messages repository required to display action results.
        //Note: You may remove following message repository initialization script,
        //however, then you should update knockout HTML templates accordingly.
        function intialize(repository) {

            repository.clean();
            repository.add(new LocaleMessage("form.new.text", "New"));
            repository.add(new LocaleMessage("form.edit.text", "Edit"));
            repository.add(new LocaleMessage("form.noRecord.text", "No record found."));
            repository.add(new LocaleMessage("form.found.text", "Found"));
            repository.add(new LocaleMessage("form.records.text", "Record(s)"));
            repository.add(new LocaleMessage("form.saved.text", "Saved"));
            repository.add(new LocaleMessage("form.failed.text", "Failed"));
            repository.add(new LocaleMessage("form.displayingPage.text", "Displaying page"));
            repository.add(new LocaleMessage("form.of.text", "of"));
            repository.add(new LocaleMessage("form.totalPages.text", ""));
            repository.add(new LocaleMessage("form.ok.text", "Ok"));
            repository.add(new LocaleMessage("standard.alertSure.text", "Are you sure to delete record?"));
            repository.add(new LocaleMessage("standard.processing.text", "Processing..."));
            repository.add(new LocaleMessage("standard.err.text", "Requested operation failed, an error occured while processing your request."));
            repository.add(new LocaleMessage("standard.ok.text", "Requested operation completed successfully."));
            repository.add(new LocaleMessage("standard.listloadok.text", "List loaded successfully."));
            repository.add(new LocaleMessage("standard.listloaderr.text", "List load failed."));

            return repository;
        }

        /**
         * CRUDView reference program implementation.
         *
         */
        var employees = new CRUDView({
            'uri': '/api/employeeempty',
            'observer': new CRUDObserver({ 'contentType': new Employee({}), 'messages': intialize(new MessageRepository()) })
        });

        employees.getObserverObject().emptyCreate = function () {

        };

        employees.getObserverObject().emptyRead = function () {

        };

        employees.getObserverObject().emptyUpdate = function () {

        };

        employees.getObserverObject().emptyDelete = function () {

        };

        employees.getObserverObject().emptyList = function () {

        };

        employees.getObserverObject().emptyCRUDM = function () {

        };

        $(function () {

            ko.validation.init({
                insertMessages: false,
                decorateElement: true,
                errorElementClass: 'error'
            });

            try {

                ko.applyBindings(employees, document.getElementsByTagName("body")[0]);
            }
            catch (e) {

                console.log(e.message);
            }

            employees.list(1);
        });
    </script>
</asp:Content>

