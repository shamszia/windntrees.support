[Microsoft Documentation]
Handling Circular Object References
By default, the JSON and XML formatters write all objects as values. If two properties refer to the same object, or if the same object appears twice in a collection, 
the formatter will serialize the object twice. This is a particular problem if your object graph contains cycles, because the serializer will throw an exception when 
it detects a loop in the graph.

var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
json.SerializerSettings.PreserveReferencesHandling = 
    Newtonsoft.Json.PreserveReferencesHandling.All;