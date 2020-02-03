import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../interface/user';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  
  private httpOptions: any = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }; 

  constructor(private http: HttpClient) { }

  authUser(user: User): Observable<any> {
    return this.http.post<User>(environment.baseApiUrl + '/Login/authenticate', user, this.httpOptions);
  }

  getUserDetails(userId: number): Observable<any> {
    return this.http.get<User>(environment.baseApiUrl + '/User/' + userId, this.httpOptions);
  }

  getUsers(): Observable<any> {
    return this.http.get<User[]>(environment.baseApiUrl + '/User/users', this.httpOptions); 
  }
}
