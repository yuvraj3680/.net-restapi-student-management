namespace StudentManagementApi.Model;
using System;
using System.ComponentModel.DataAnnotations;


public class Student{
    public int studentid{get;set;}

    [Required]
    public String studentname{get;set;}="";

    [Required]
     public String studentcource{get;set;}="";

      [Required]
     public String studentjoindate{get;set;}="";
}