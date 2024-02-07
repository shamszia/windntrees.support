<h1>windntrees.support</h1>
<p><a href="#">windntrees.support</a> is a reference projects repository implementing CRUD2CRUD (CRUDS) application architecture.</p>

<pre>
[Server Side]
CRUDSource(s) --- CRUDController(s) -- CRUDProcessor(s) --- CRUDService(s)

              ||| data / objects / entities / concepts ||| 

[Client Side]
CRUDSource(s) --- CRUDController(s) -- CRUDProcessor(s) --- CRUDConsumer(s)
</pre>

<h2>dotnet</h2>
<p>For dotnet reference projects refer <a href="http://invincibletec.com/tutorial/index/windntrees">Tutorials</a>.</p>

<h2>websites</h2>
<p><a href="http://www.invincibletec.com" title="www.invincibletec.com">www.invincibletec.com</a></p>
<p><a href="http://16.170.242.60:8000" title="backup website">backup website</a></p>

<h2>maven</h2>
<p><a href="#">maven</a> repository is a reference project impmentation based on thymeleaf view engine and developed in netbeans IDE using java.</p>

<h2>help</h2>
<p>In order to get API reference of <a href="https://github.com/shamszia/windntrees">windntrees</a> place "help" repository folder contents in a webserver or a vritual directory path.</p>

<h2>issues</h2>
<p>For issues and support contact me at <a href="https://github.com/shamszia/windntrees.support/issues">issues<a>.</p>

<pre>Updated On: 2022-11-21</pre>
<h2>CRUD2CRUD CB (Callback) Repository Example</h2>
<hr/>
<p>This program computes %age of server side input score value on all subscribed client side data channels (90%, 80%, 70%, and 60%).</p>
<hr/>
<p>Example elaborates CRUD2CRUD interface CRUDM method scaling in server and client side repositories.
With server and client side CRUD2CRUD interfacing (CB) repositories channels establish al-round communication.</p>
<p>In addition to CRUDL operations (Create, Read, Update, Delete and List), this example implements following CRUDM Scale (Read, Avg, Max, Min and FailScore) in CB (Callback) Repositories.</p>
<hr/>
<h2>Use Following Console Commands To Operate This Program:</h2>
<p>[make sure clients subscribe channels before executing commands]</p>
<pre>
1. Create Score_Value (Create 100), initializes clients %age score to immediate input value.
2. Update Score_Value (Update 100), add clients %age score to existing immediate input value. Repeat this step for adding score. Repeat update command for adding score.
3. Max (Max), lists maximum input score values of all subscribed channels.
4. Min (Min), lists minimum input score values of all subscribed channels.
5. Avg (Avg), lists avg of %age score values of all subscribed channels.
6. FailScore (FailScore), lists total of %age fail score values of all subscribed channels.
</pre>
<hr/>
<p>CRUD2CRUD solves data communication problem, CRUDM scales method invocations without re-defining communication interface.</p>
  
https://github.com/shamszia/windntrees.support/blob/master/windntrees-crud2crud-cb/server-netclient-coreclient.png
<div><img title="" src="https://github.com/shamszia/windntrees.support/blob/master/windntrees-crud2crud-cb/server-netclient-coreclient.png" /></div>

https://github.com/shamszia/windntrees.support/blob/master/windntrees-crud2crud-cb/server-netclient-coreclient-3.png
<div><img title="" src="https://github.com/shamszia/windntrees.support/blob/master/windntrees-crud2crud-cb/server-netclient-coreclient-3.png" /></div>
