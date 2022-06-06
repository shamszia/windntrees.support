using System;
using System.Runtime.Serialization;

namespace SharedLibrary
{
	[DataContract]
	public class Student
	{
		[DataMember]
		public string RollNo { get; set; }
		[DataMember]
		public string Name { get; set; }
	}
}
