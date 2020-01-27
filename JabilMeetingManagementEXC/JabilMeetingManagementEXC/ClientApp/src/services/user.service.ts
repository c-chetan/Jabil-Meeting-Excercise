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
    return this.http.post<User>(environment.baseApiUrl + '/api/Login/authenticate', user, this.httpOptions);
  }
}
