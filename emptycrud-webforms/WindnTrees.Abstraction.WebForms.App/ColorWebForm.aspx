<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ColorWebForm.aspx.cs" Inherits="WindnTrees.Abstraction.WebForms.App.ColorWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceTemplates" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>WindnTrees CRUD2CRUD Example</h3>

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
                                    <div>
                                        <h4>EmptyCRUD</h4>
                                    </div>
                                    <div class='input-group'>
                                        <span class='input-group-btn'>
                                            <button data-bind="click: function(data, event) { create(); }" class='btn btn-default' title='New'><span>New</span></button>
                                            <button data-bind="click: function(data, event) { update(); }" class='btn btn-default' title='Update'><span>Update</span></button>
                                            <button data-bind="click: function(data, event) { deleteRecord(); }" class='btn btn-default' title='Delete'><span>Delete</span></button>
                                        </span>
                                        <input class='form-control' data-bind='value: Keyword' type='text' placeholder='Keyword' />
                                        <span class='input-group-append'>
                                            <button data-bind="click: function() { read(); }" class='btn btn-default' type='button' title='press to search'><span>Read</span></button>
                                            <button data-bind="click: function() { list(); }" class='btn btn-default' type='button' title='press to search'><span>Search</span></button>
                                        </span>
                                    </div>
                                    <div>
                                        <h4>EmptyCRUD with Target</h4>
                                    </div>
                                    <div class='input-group'>
                                        <span class='input-group-btn'>
                                            <button data-bind="click: function(data, event) { create({ target: 'createCRUD' }); }" class='btn btn-default' title='New'><span>New</span></button>
                                            <button data-bind="click: function(data, event) { update({ target: 'updateCRUD' }); }" class='btn btn-default' title='Update'><span>Update</span></button>
                                            <button data-bind="click: function(data, event) { deleteRecord({ target: 'deleteCRUD' }); }" class='btn btn-default' title='Delete'><span>Delete</span></button>
                                        </span>
                                        <input class='form-control' data-bind='value: Keyword' type='text' placeholder='Keyword' />
                                        <span class='input-group-append'>
                                            <button data-bind="click: function() { read({ target: 'readCRUD' }); }" class='btn btn-default' type='button' title='press to search'><span>Read</span></button>
                                            <button data-bind="click: function() { list({ target: 'listCRUD' }); }" class='btn btn-default' type='button' title='press to search'><span>Search</span></button>
                                        </span>
                                    </div>
                                    <div>
                                        <h4>EmptyCRUD with __Target</h4>
                                    </div>
                                    <div class='input-group'>
                                        <span class='input-group-btn'>
                                            <button data-bind="click: function(data, event) { create({ __target: 'CreateCRUD' }); }" class='btn btn-default' title='New'><span>New</span></button>
                                            <button data-bind="click: function(data, event) { update({ __target: 'UpdateCRUD' }); }" class='btn btn-default' title='Update'><span>Update</span></button>
                                            <button data-bind="click: function(data, event) { deleteRecord({ __target: 'DeleteCRUD' }); }" class='btn btn-default' title='Delete'><span>Delete</span></button>
                                        </span>
                                        <input class='form-control' data-bind='value: Keyword' type='text' placeholder='Keyword' />
                                        <span class='input-group-append'>
                                            <button data-bind="click: function() { read({ __target: 'ReadCRUD' }); }" class='btn btn-default' type='button' title='press to search'><span>Read</span></button>
                                            <button data-bind="click: function() { list({ __target: 'ListCRUD' }); }" class='btn btn-default' type='button' title='press to search'><span>Search</span></button>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="fixed-table-container">
                                <div class="fixed-table-header"></div>
                                <div class="fixed-table-body">
                                    <table class="table table-hover grid-style-0">
                                        <thead>
                                            <tr>
                                                <th class="col-4 order-0" scope="col">
                                                    <span class="d-flex align-content-start" title="Name">Name</span>
                                                </th>
                                                <th class="col-8 order-1" scope="col">
                                                    <span class="d-flex align-content-start" title="Description">Description</span>
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody data-bind="foreach: { data: getObservableRecords(), as: 'record' }">
                                            <tr>
                                                <td><span class="d-flex align-content-start" data-bind="text: Name()"></span></td>
                                                <td><span class="d-flex align-content-start" data-bind="text: Description()"></span></td>
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceScript" runat="server">
    <script src="Scripts/knockout-3.5.1.js"></script>
    <script src="Scripts/knockout.validation.js"></script>

    <script src="Scripts/windntrees-132.min.js"></script>
    <script src="Scripts/Model/Color.js" type="text/javascript"></script>

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

        var crudView = new CRUDView({
            'uri': '/api/colorempty',
            'observer': new CRUDObserver({ 'contentType': new Color({}), 'messages': intialize(new MessageRepository()) }),
            'empty': true
        });

        crudView.getObserverObject().deleteRecord = function(data) {

            if (data !== null && data !== undefined) {

                crudView.getObserverObject().delete(data);
            }
            else {
                crudView.getObserverObject().delete();
            }
        };

        crudView.getObserverObject().updateList = function (event, eventData) {

            crudView.getObserverObject().Records([]);

            var list = [];
            list.push(new Color(eventData.result));
            crudView.getObserverObject().Records(list);
        };

        $(function () {

            ko.applyBindings(crudView, document.getElementsByTagName("body")[0]);
        
            crudView.subscribeEvent('record.after.rendering.view.CRUD.WindnTrees', crudView.getObserverObject().updateList);
        });

    </script>
</asp:Content>
