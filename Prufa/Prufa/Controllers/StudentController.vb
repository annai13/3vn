﻿Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace Prufa
    Public Class StudentController
        Inherits System.Web.Mvc.Controller

        Private db As New MegaTitleEntities

        ' GET: /Student/
        Function Index() As ActionResult
            Return View(db.Student.ToList())
        End Function

        ' GET: /Student/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim student As Student = db.Student.Find(id)
            If IsNothing(student) Then
                Return HttpNotFound()
            End If
            Return View(student)
        End Function

        ' GET: /Student/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: /Student/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include := "StudentID,LastName,FirstName,EnrollmentDate")> ByVal student As Student) As ActionResult
            If ModelState.IsValid Then
                db.Student.Add(student)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If 
            Return View(student)
        End Function

        ' GET: /Student/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim student As Student = db.Student.Find(id)
            If IsNothing(student) Then
                Return HttpNotFound()
            End If
            Return View(student)
        End Function

        ' POST: /Student/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include := "StudentID,LastName,FirstName,EnrollmentDate")> ByVal student As Student) As ActionResult
            If ModelState.IsValid Then
                db.Entry(student).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(student)
        End Function

        ' GET: /Student/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim student As Student = db.Student.Find(id)
            If IsNothing(student) Then
                Return HttpNotFound()
            End If
            Return View(student)
        End Function

        ' POST: /Student/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim student As Student = db.Student.Find(id)
            db.Student.Remove(student)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
