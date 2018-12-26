ko.bindingHandlers.dateValue = {

    init: function (element, observer, allBindings, viewModel, bindingContext) {
        var instance = this;
        instance.Element = element;
        instance.Observer = observer;
        $(element).datepicker({
            format: 'yyyy-mm-dd'
        });
        $(element).datepicker("getDate");

        if (instance.Observer !== null && instance.Observer !== undefined) {
            //if its observer then set value
            if (typeof (instance.Observer) === "function") {

                var valueObserver = instance.Observer();
                element.value = moment(moment.utc(valueObserver()).toDate()).format('YYYY-MM-DD');
                $(element).datepicker("setDate", element.value);
            } else {
                element.value = moment(moment.utc(instance.Observer()).toDate()).format('YYYY-MM-DD');
            }
        }
    },
    update: function (element, observer, allBindingsAccessor, viewModel, bindingContext) {
        var instance = this;
        instance.Element = element;
        instance.Observer = observer;

        instance.ValueObserver = function (event) {

            if (instance.Observer !== null && instance.Observer !== undefined) {

                if (typeof (instance.Observer) === "function") {

                    var valueObserver = instance.Observer();
                    valueObserver(event.target.value);
                } else {

                    instance.Observer = event.target.value;
                }
            }
        }

        $(element).change(instance.ValueObserver);
    }
}

/* Adds the binding timeValue to use with bootstra-timepicker 
   This works with the http://jdewit.github.io/bootstrap-timepicker/index.html
   component.
   Use: use with an input, make sure to use your input with this format
   <div class="bootstrap-timepicker pull-right">
       <input id="timepicker3" type="text" class="input-small">
   </div>
*/
ko.bindingHandlers.timeValue = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var tpicker = $(element).timepicker();

        tpicker.on('changeTime.timepicker', function (e) {

            //Asignar la hora y los minutos
            var value = valueAccessor();
            if (!value) {
                throw new Error('timeValue binding observable not found');
            }
            var date = ko.unwrap(value);
            var mdate = moment(date || new Date());
            var hours24;
            if (e.time.meridian == "AM") {
                if (e.time.hours == 12)
                    hours24 = 0;
                else
                    hours24 = e.time.hours;
            }
            else {
                if (e.time.hours == 12) {
                    hours24 = 12;
                }
                else {
                    hours24 = e.time.hours + 12;
                }
            }

            mdate.hours(hours24)
            mdate.minutes(e.time.minutes);
            $(element).data('updating', true);
            value(mdate.toDate());
            $(element).data('updating', false);


        })
    },
    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        //Avoid recursive calls
        if ($(element).data('updating')) {
            return;
        }
        var date = ko.unwrap(valueAccessor());

        if (date) {
            var time = moment(date).format("hh:mm a");
            $(element).timepicker('setTime', time);
        }
    }
}

ko.unwrap = ko.unwrap || ko.utils.unwrapObservable;
