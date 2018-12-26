using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Controls.List
{
    /// <summary>
    /// List composer control. 
    /// </summary>
    public class ListComposer
    {
        /// <summary>
        /// Composes list related basic views.
        /// </summary>
        /// <param name="formId">This is form id that is integrated within content.</param>
        /// <returns></returns>
        public static MvcHtmlString composeBasicViews(string formId)
        {
            string basicViews = "<section> " +
                                        "<script type = 'text/html' id='actions'> " +
                                        "     <div class='form-row'> " +
                                        "      <div class='input-group'> " +
                                        "          <span class='input-group-prepend'> " +
                                        "              <button data-bind='click: function() { resetForm(); }' class='btn btn-default' data-toggle='modal' data-target='" + formId + "' title='" + SharedLibrary.Resources.Global.FormMessages.NewD + "'><span>" + SharedLibrary.Resources.Global.FormMessages.New + "</span></button> " +
                                        "          </span> " +
                                        "          <input data-bind='value: Keyword' type='text' placeholder='" + SharedLibrary.Resources.Global.FormMessages.Keyword + "' class='form-control' /> " +
                                        "          <span class='input-group-append'> " +
                                        "              <button data-bind='click: function() { find(1); }' class='btn btn-default' type='button' title='" + SharedLibrary.Resources.Global.FormMessages.SearchD + "'><span>" + SharedLibrary.Resources.Global.FormMessages.Search + "</span></button> " +
                                        "          </span> " +
                                        "      </div> " +
                                        "  </div> " +
                                        "  <br /> " +
                                        "</script> " +

                                        "<script type = 'text/html' id='listitem'> " +
                                        "    <li class='inner-item-style'> " +
                                        "        <span data-bind='text: Name(), attr: {title: Description()}'></span> " +
                                        "        <span class=''> " +
                                        "            <span><a class='green' href='#' data-bind='click: function(data, event) { $parent.resetFormForEditing($index); }' data-toggle='modal' data-target='" + formId + "' title='" + SharedLibrary.Resources.Global.FormMessages.EditD + "'><i class='fa fa-edit text-success'></i></a></span> " +
                                        "            <span><a class='red' href='#' data-bind='click: function(data, event) { $parent.delete($data); }' title='" + SharedLibrary.Resources.Global.FormMessages.DeleteD + "'><i class='fa fa-times text-danger'></i></a></span> " +
                                        "        </span> " +
                                        "    </li> " +
                                        "</script> " +

                                        "<script type = 'text/html' id='standard_listings'> " +
                                        "        <div class='input-group' data-bind='if: ListNavigator().calculateTotalPages() > 1'> " +
                                        "           <span class='input-group-prepend' data-bind='css: {disabled: CurrentList() == 1}'><a href = '#' data-bind='click: function(){ if (CurrentList() > 1) {find(CurrentList() - 1); } }'><span class='input-group-text'>" + SharedLibrary.Resources.Global.FormMessages.PrevPage + "</span></a></span> " +
                                        "           <span class='input-group-append' data-bind='css: {disabled: CurrentList() == ListNavigator().calculateTotalPages()}'><a href = '#' data-bind='click: function(){ if (CurrentList() < ListNavigator().calculateTotalPages()) {find(CurrentList() + 1); } }'><span class='input-group-text'>" + SharedLibrary.Resources.Global.FormMessages.NextPage + "</span></a></span> " +
                                        "        </div> " +
                                        "</script> " +
                                    "</section> ";

            return new MvcHtmlString(basicViews);
        }

        /// <summary>
        /// Composes list related standard HTML content submission widgets or controls.
        /// </summary>
        /// <param name="formId">This is form id that is integrated within content.</param>
        /// <returns></returns>
        public static MvcHtmlString composeStandardActions(string actionId, string formId, Boolean readOnly = false, string searchAction = null, string searchActionParams = null, bool modalForm = true, string newDialogAttributes = null, string actionContentId = null, string searchLink = null)
        {
            string newFormAttributes = "data-bind='click: function(data, event) { resetForm(); }' class='btn btn-default' data-toggle='modal' data-target='" + formId + "'";

            if (!modalForm)
            {
                newFormAttributes = "data-bind=\"click: function(data, event) { resetForm(); $('" + formId + "').dialog('open'); }\" class='btn btn-default'";
            }

            newFormAttributes = newDialogAttributes != null ? newDialogAttributes : newFormAttributes;

            var readOnlyContent = "";
            if (!readOnly)
            {
                readOnlyContent = "<span class='input-group-btn'><button " + newFormAttributes + " title='" + SharedLibrary.Resources.Global.FormMessages.NewD + "'><span>" + SharedLibrary.Resources.Global.FormMessages.New + "</span></button></span>";
            }

            actionId = actionId == null ? "actions" : actionId;

            actionContentId = actionContentId == null ? "" : actionContentId;

            searchAction = searchAction == null ? "find" : searchAction;
            searchAction = searchActionParams == null ? string.Format("{0}(1);", searchAction) : string.Format("{0}({1});", searchAction, searchActionParams);
            searchLink = searchLink != null ? searchLink : "";

            string collapseClass = searchLink.Length > 0 ? "collapse" : "";

            string standardActions = "<script type = 'text/html' id='" + actionId + "'> " +
                                            searchLink +
                                        "   <div class='form-group " + collapseClass + "' id='" + actionContentId + "'> " +
                                        "        <div class='input-group'> " +
                                                    readOnlyContent +
                                        "            <input class='form-control' data-bind='value: Keyword' type='text' placeholder='" + SharedLibrary.Resources.Global.FormMessages.Keyword + "' /> " +
                                        "            <span class='input-group-append'> " +
                                        "                <button data-bind='click: function() { " + searchAction + " }' class='btn btn-default' type='button' title='" + SharedLibrary.Resources.Global.FormMessages.SearchD + "'><span>" + SharedLibrary.Resources.Global.FormMessages.Search + "</span></button> " +
                                        "            </span> " +
                                        "        </div> " +
                                        "    </div> " +
                                        "</script> ";

            return new MvcHtmlString(standardActions);
        }

        /// <summary>
        /// Composes grid related standard listing content.
        /// </summary>
        /// <param name="formId">This is form id that is integrated within content.</param>
        /// <returns></returns>
        public static MvcHtmlString composeStandardListing(string listingId, string formId, Boolean navLinks = false, string searchAction = null, string selectList = null, string nextList = null, string prevList = null, string postSelectionAction = null)
        {

            listingId = listingId == null ? "standard_listings" : listingId;

            searchAction = searchAction == null ? "find" : searchAction;


            var navSelectList = selectList == null ? "Number" : selectList;
            

            selectList = selectList == null ? "CurrentList()" : selectList;
            nextList = nextList == null ? "CurrentList() + 1" : nextList;
            prevList = prevList == null ? "CurrentList() - 1" : prevList;
            postSelectionAction = postSelectionAction == null ? "" : postSelectionAction;

            var selectAction = string.Format("{0}({1});{2}", searchAction, selectList, postSelectionAction);
            var navLinkSizeSelectList = string.Format("{0}({1});", "find", "CurrentList()", "");

            var navSelectAction = string.Format("{0}({1});{2}", searchAction, navSelectList, postSelectionAction);
            var searchActionNext = string.Format("{0}({1});{2}", searchAction, nextList, postSelectionAction);
            var searchActionPrev = string.Format("{0}({1});{2}", searchAction, prevList, postSelectionAction);

            var selectListings = "<div class='input-group justify-content-end' data-bind='if: ListNavigator().calculateTotalPages() > 1'> " +
                "<span class='input-group-prepend' data-bind='css: {disabled: CurrentList() == 1}'><a href = '#' data-bind='click: function(){ if (CurrentList() > 1) { " + searchActionPrev + " } }'><span class='input-group-text'>" + SharedLibrary.Resources.Global.FormMessages.PrevPage + "</span></a></li> " +
                "<select class='form-control' data-bind=\"value: CurrentList, options: ListNavigator().getLists(), optionsText: 'Number', optionsValue:'Number', event: {change: function() { " + selectAction + " }}\" id='form-field-select-paging' style='width:auto;' /> " +
                "<span class='input-group-append' data-bind='css: {disabled: CurrentList() == ListNavigator().calculateTotalPages()}'><a href = '#' data-bind='click: function(){ if (CurrentList() < ListNavigator().calculateTotalPages()) { " + searchActionNext + " } }'><span class='input-group-text'>" + SharedLibrary.Resources.Global.FormMessages.NextPage + "</span></a></li> " +
                "</div>";

            var navListings = "<nav class=\"d-flex justify-content-end\" aria-label=\"Listings\">" +
                "<ul class=\"pagination\">" +
                "<li class=\"page-item\" data-bind=\"css: {disabled: CurrentList() == 1}\"><a class=\"page-link\" href=\"#\" data-bind=\"click: function() { " + searchActionPrev + " }\">" + SharedLibrary.Resources.Global.FormMessages.PrevPage + "</a></li>" +
                "<!-- ko foreach: ListNavigator().getLists() -->" +
                "<li class=\"page-item\"><a class=\"page-link\" href=\"#\" data-bind=\"click: function() { " + navSelectAction + " }\"><span data-bind=\"text: Number\"></span></a></li>" +
                "<!-- /ko -->" +
                "<li class=\"page-item\" data-bind=\"css: {disabled: CurrentList() == ListNavigator().calculateTotalPages()}\"><a class=\"page-link\" href=\"#\" data-bind=\"click: function() { " + searchActionNext + " }\">" + SharedLibrary.Resources.Global.FormMessages.NextPage + "</a></li>" +
                "</ul>" +
                "</nav>";
            

            string standardListing = "   <script type = 'text/html' id='" + listingId + "'> " +
                                        "   <div class='col order-first'> " +
                                        "        <div class='input-group justify-content-start' dir='ltr'> " +
                                        "            <span class='input-group-prepend'><span class='input-group-text'>" + SharedLibrary.Resources.Global.FormMessages.ListSize + "</span></span> " +
                                        "            <select class='form-control col-2' data-bind=\"value: ListSize, event: {change: function() { " + (navLinks ? navLinkSizeSelectList : selectAction) + " }}\" id='form-field-select-1' style='width:auto;'> " +
                                        "                <option value = '10'> 10 </option> " +
                                        "                <option value ='20'>20</option> " +
                                        "                <option value = '50'> 50 </option> " +
                                        "                <option value ='100'>100</option> " +
                                        "            </select> " +
                                        "        </div> " +
                                        "    </div> " +

                                        "    <div class='col order-last'> " +
                                             (navLinks ? navListings : selectListings) +
                                        "    </div> " +
                                        "</script> ";

            return new MvcHtmlString(standardListing);
        }

        /// <summary>
        /// Composes a content list based on list id, title, actions, inner list and list customization (or listing) content.
        /// </summary>
        /// <param name="listid">list id</param>
        /// <param name="actions">listing actions</param>
        /// <param name="listings">list selection and navigating information.</param>
        /// <param name="listCssClass">list css style class</param>
        /// <param name="contents">list contents binding information</param>
        /// <param name="list">provide custom list here.</param>
        /// <returns></returns>
        public static MvcHtmlString composeList(string listid, string cssClass, string actions = null, string listings = null, string listCssClass = null, string contents = null, string list = null, string outerList = null, string messages = null, string status = null)
        {   
            actions = actions == null ? "<div data-bind=\"template: {name: 'actions'}\"></div>" : actions;
            listings = listings == null ? "<div class='form-row outer-item-style' data-bind=\"template: {name: 'standard_listings'}\"></div>" : listings;

            cssClass = cssClass == null ? "container" : cssClass;

            listCssClass = listCssClass == null ? "" : listCssClass;
            contents = contents == null ? "data-bind=\"template: {name: 'listitem', foreach: Records}\"" : contents;

            if (list == null)
            {
                list = "<ul id= '" + listid + "' class='" + listCssClass + "' " + contents + " ></ul>\n";
            }

            if (outerList != null)
            {
                //outer list will provide a place holder for inner list or list.
                list = string.Format(outerList, list);
            }

            messages = messages == null ? "<span class='col-11 order-first result' data-bind=\"template: {name: 'results_messages'}\"></span> " : messages;
            status = status == null ? "<span class='col-1 order-last status' data-bind=\"template: {name: 'results_processing'}\"></span>" : status;

            var message_status = string.Format("<div class='row'>{0}{1}</div>", messages, status);
            var errors_list = string.Format("<div class='row'>{0}</div>", "<div data-bind='if: Errors().length > 0'><ul class='errorlist' data-bind=\"template: {name: 'list_error_messages', foreach: Errors}\"></ul></div>");

            string contentList = "<div class='" + cssClass + "'> " +
                message_status +
                errors_list +
                actions +
                list +
                listings +
                "</div> ";

            return new MvcHtmlString(contentList);
        }
    }
}
