Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace Prufa
    Public Class EnrollmentController
        Inherits System.Web.Mvc.Controller

        Private db As New MegaTitleEntities

        ' GET: /Enrollment/
        Function Index() As ActionResult
            Dim enrollment = db.Enrollment.Include(Function(e) e.Course).Include(Function(e) e.Student)
            Return View(enrollment.ToList())
        End Function

        ' GET: /Enrollment/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim enrollment As Enrollment = db.Enrollment.Find(id)
            If IsNothing(enrollment) Then
                Return HttpNotFound()
            End If
            Return View(enrollment)
        End Function

        ' GET: /Enrollment/Create
        Function Create() As ActionResult
            ViewBag.CourseID = New SelectList(db.Course, "CourseID", "Title")
            ViewBag.StudentID = New SelectList(db.Student, "StudentID", "LastName")
            Return View()
        End Function

        ' POST: /Enrollment/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include := "EnrollmentID,Grade,CourseID,StudentID")> ByVal enrollment As Enrollment) As ActionResult
            If ModelState.IsValid Then
                db.Enrollment.Add(enrollment)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If 
            ViewBag.CourseID = New SelectList(db.Course, "CourseID", "Title", enrollment.CourseID)
            ViewBag.StudentID = New SelectList(db.Student, "StudentID", "LastName", enrollment.StudentID)
            Return View(enrollment)
        End Function

        ' GET: /Enrollment/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim enrollment As Enrollment = db.Enrollment.Find(id)
            If IsNothing(enrollment) Then
                Return HttpNotFound()
            End If
            ViewBag.CourseID = New SelectList(db.Course, "CourseID", "Title", enrollment.CourseID)
            ViewBag.StudentID = New SelectList(db.Student, "StudentID", "LastName", enrollment.StudentID)
            Return View(enrollment)
        End Function

        ' POST: /Enrollment/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include := "EnrollmentID,Grade,CourseID,StudentID")> ByVal enrollment As Enrollment) As ActionResult
            If ModelState.IsValid Then
                db.Entry(enrollment).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.CourseID = New SelectList(db.Course, "CourseID", "Title", enrollment.CourseID)
            ViewBag.StudentID = New SelectList(db.Student, "StudentID", "LastName", enrollment.StudentID)
            Return View(enrollment)
        End Function

        ' GET: /Enrollment/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim enrollment As Enrollment = db.Enrollment.Find(id)
            If IsNothing(enrollment) Then
                Return HttpNotFound()
            End If
            Return View(enrollment)
        End Function

        ' POST: /Enrollment/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim enrollment As Enrollment = db.Enrollment.Find(id)
            db.Enrollment.Remove(enrollment)
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
