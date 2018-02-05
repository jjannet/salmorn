import { Injectable } from '@angular/core';
import { User } from '../models/user';

@Injectable()
export class TokenManageService {
  tokenKey: string = 'salmorn-token';
  userKey: string = 'salmorn-usr';

  constructor() { }

  // Token function
  setToken(token: string) {
    localStorage.setItem(this.tokenKey, token);
  }

  clearToken() {
    localStorage.removeItem(this.tokenKey);
  }

  getToken() {
    return localStorage.getItem(this.tokenKey);
  }



  // User function
  setUser(user: User) {
    localStorage.setItem(this.userKey, JSON.stringify(user));
  }

  clearUser() {
    localStorage.removeItem(this.userKey);
  }

  getUser(): User {
    var js = localStorage.getItem(this.userKey);
    if (js && js != '') {
      return JSON.parse(js) as User;
    } else {
      return null;
    }
  }

  IsAuthen() {
    let u = this.getUser();
    if(u == null) return false;
    else return true;
  }

}
