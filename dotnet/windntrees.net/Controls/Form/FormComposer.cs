using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Controls.Form
{
    /// <summary>
    /// Form composer control.
    /// </summary>
    public class FormComposer
    {
        /// <summary>
        /// Composes HTML form based on form id, content and form actions.
        /// </summary>
        /// <param name="formId">This is form id.</param>
        /// <param name="content">These are content input and or result output fields.</param>
        /// <param name="actions">These are form submission buttons.</param>
        /// <returns></returns>
        public static MvcHtmlString composeForm(string formId, string formObject = null, string title = null, string formTitle = null, string content = null, string actions = null, string createFunction = null, string updateFunction = null, string scopeObject = null, bool modal = true, bool display = false)
        {
            string modalFormAttributes = string.Empty;
            string modalFormCrossButton = string.Empty;
            string formCloseButton = string.Empty;
            string formOkButton = string.Empty;
            string modalDialogAttributes = string.Empty;
            string modalContentAttributes = string.Empty;

            if (modal)
            {
                //modal form then take on following inputs
                modalFormAttributes = " class='modal fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' " + (display ? "" : " style='display: none;' ");
                modalFormCrossButton = "<button type = 'button' class='col order-1 close d-flex justify-content-end' data-dismiss='modal'> <span aria-hidden='true'>&times;</span><span class='sr-only'>" + SharedLibrary.Resources.Global.FormMessages.Close + "</span></button> ";
                formCloseButton = "<button type = 'button' id ='btnCloseAddForm' class='btn btn-default' data-dismiss='modal'><span>Close</span></button>";
                formOkButton = "<button type = 'button' id='btnOK' class='btn btn-primary' data-dismiss='modal'> <span>" + SharedLibrary.Resources.Global.FormMessages.Done + "</span></button>";
                modalDialogAttributes = "class='modal-dialog modal-dialog-centered'";
                modalContentAttributes = "class='modal-content'";
            }
            else
            {
                formCloseButton = "<button type = \"button\" onclick=\"javascript: $('#" + formId + "').dialog('close');\" id=\"btnCloseAddForm\" class=\"btn btn-default\"><span>" + SharedLibrary.Resources.Global.FormMessages.Close + "</span></button>";
                formOkButton = "<button type = \"button\" onclick=\"javascript: $('#" + formId + "').dialog('close');\" id=\"btnOK\" class=\"btn btn-default\"><span>" + SharedLibrary.Resources.Global.FormMessages.Done + "</span></button>";
            }

            //form content
            string formContent = "<section> " +
                                        "<div class='form-group form-group-sm'> " +
                                        "   <div class='col-3'> " +
                                        "       <label class='control-label' for='Name'> " +
                                        "           <span>" + SharedLibrary.Resources.Global.FormMessages.FieldName + "</span> " +
                                        "       </label> " +
                                        "       <input data-bind='value: $parent.EditMode() ? name : name' id='Name' type='text' title='" + SharedLibrary.Resources.Global.FormMessages.FieldNameD + "' maxlength='50' placeholder='' class='form-control' /><span class='error' data-bind='validationMessage: name'></span> " +
                                        "   </div> " +
                                        "   <div class='col-9'> " +
                                        "       <label class='control-label' for='Description'> " +
                                        "           <span>" + SharedLibrary.Resources.Global.FormMessages.FieldDescription + "</span> " +
                                        "       </label> " +
                                        "       <input data-bind='value: $parent.EditMode() ? description : description' id='Description' type='text' title='" + SharedLibrary.Resources.Global.FormMessages.FieldDescriptionD + "' maxlength='200' placeholder='' class='form-control' /><span class='error' data-bind='validationMessage: description'></span> " +
                                        "   </div> " +
                                        "</div> " +
                                        "<div class='clear-fix'> " +
                                        "</div> " +
                                        "</section> ";

            formContent = content != null ? content : formContent;

            scopeObject = scopeObject == null ? "" : scopeObject;


            createFunction = createFunction == null ? "create()" : createFunction;
            updateFunction = updateFunction == null ? "update()" : updateFunction;

            createFunction = scopeObject + createFunction;
            updateFunction = scopeObject + updateFunction;
            string editMode = scopeObject + "getEditMode()";


            //form actions
            string saveActions = "<section>" + formCloseButton +
                                    "   <button type = 'button' data-bind='click: function() { " + editMode +" ? " + updateFunction + " : " + createFunction + "; }' id='btnAddEdit' class='btn btn-primary'>  " +
                                    "       <span>" + SharedLibrary.Resources.Global.FormMessages.Save + "</span>  " +
                                    "   </button>  " +
                                    "</section>";

            //form ok
            string uploadActions = "<section>" + formCloseButton + formOkButton + "</section>";
            //form ok
            string viewActions = "<section>" + formCloseButton + formOkButton + "</section>";

            String formActions = saveActions;
            if (actions != null)
            {
                if (actions.Equals("save"))
                {
                    formActions = saveActions;
                }
                else if (actions.Equals("upload"))
                {
                    formActions = uploadActions;
                }
                else if (actions.Equals("view"))
                {
                    formActions = viewActions;
                }
                else
                {
                    formActions = actions;
                }
            }

            if (title == null)
            {
                title = "";
            }

            if (formTitle == null)
            {
                formTitle = "<span data-bind='text: getEditMode() ? getEditModeCaption() : getNewModeCaption()'></span>";
            }

            formObject = formObject == null ? "data-bind='with: getObservableFormObject()'" : formObject;

            var messages = "<span class='col-11 order-first result' data-bind=\"template: {name: 'results_messages'}\"></span>";
            var status = "<span class='col-1 order-last status' data-bind=\"template: {name: 'results_processing'}\"></span>";

            //form
            string form = "<section> " +
                                "<div id='" + formId + "' " + modalFormAttributes + " title='" + title + "' > " +
                                "    <div " + modalDialogAttributes + "> " +
                                "        <div " + modalContentAttributes + "> " +
                                "            <div class='modal-header form-row'> " +
                                "                <h4 class='col order-0 modal-title d-flex justify-content-start' id='modalFormLabel'> " +
                                                            formTitle +
                                "                </h4> " +
                                                    modalFormCrossButton +
                                "            </div> " +
                                "            <div class='modal-body'> " +
                                "                <div class='form-group'> " +
                                "                   <div class='form-row' data-bind='visible: (RequestProgress() > 0 &&  RequestProgress() < 100)'> " +
                                "                       <div class='col-12 progress' style='display: flex' data-bind=\"template: {name: 'request_progress'}\"></div> " +
                                "                   </div> " +
                                "                   <div class='form-row'> " +
                                                        messages +
                                                        status +
                                "                   </div> " +
                                "                   <div class='form-row'>" +
                                "                       <div class='col-12' data-bind='if: Errors().length > 0'> " +
                                "                           <ul class='errorlist' data-bind=\"template: {name: 'list_error_messages', foreach: Errors}\"></ul> " +
                                "                       </div> " +
                                "                   </div>" +
                                "                </div> " +
                                "               <div " + formObject + " > " +
                                                        formContent + // form content
                                "               </div> " +
                                "            </div> " +
                                "            <div class='modal-footer'> " +
                                "                <div class='_mdpullleft'> " +
                                            formActions + // form actions
                                "                </div> " +
                                "            </div> " +
                                "        </div> " +
                                "    </div> " +
                                "</div> " +
                                "</section>";

            return new MvcHtmlString(form);
        }
    }
}
