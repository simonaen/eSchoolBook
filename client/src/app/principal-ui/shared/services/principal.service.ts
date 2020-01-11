import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable} from "rxjs";
import {tap} from "rxjs/operators";
import {SchoolUsersTableData} from "../models/SchoolUsersTableData";
import {StudentDialogData} from "../models/StudentDialogData";

@Injectable()
export class PrincipalService {
   private readonly serverUrl = "http://localhost:5000";

   constructor(private http: HttpClient) {
   }
   /*Get all students in school*/
   public getStudentsData$(schoolId: string): Observable<SchoolUsersTableData[]>{
      return this.http.get<SchoolUsersTableData[]>(`${this.serverUrl}/students/school/${schoolId}`).pipe(
          tap(x => console.log(x))
      );
   };

   /*Get single student data*/
   public getStudentData$(studentId: string): Observable<StudentDialogData>{
      console.log(1);
      return this.http.get<StudentDialogData>(`${this.serverUrl}/students/dialog/${studentId}`).pipe(
          tap(x => console.log(x))
      );
   };
   /*Get all teachers in school*/
   public getTeachersData$(schoolId: string): Observable<SchoolUsersTableData[]>{
      return this.http.get<SchoolUsersTableData[]>(`${this.serverUrl}/teachers/school/${schoolId}`).pipe(
          tap(x => console.log(x))
      );
   };
}
