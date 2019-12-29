import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { SchoolUserRoles } from "../enums/school-user-roles";

export interface UserModel {
   schoolUserId: string;
   fullName: string;
   role: SchoolUserRoles;
}

@Injectable({
   providedIn: 'root'
})
export class UserService {
   private readonly apiEndpoint = "api/users";

   constructor(private http: HttpClient) {
   }

   getUsers$(): Observable<UserModel[]> {
      return this.http.get<UserModel[]>("http://localhost:5000/" + this.apiEndpoint);
   }
}
