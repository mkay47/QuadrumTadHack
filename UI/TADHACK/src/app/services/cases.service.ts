import { Injectable } from '@angular/core';
import {API_URL} from './api-constants.constants';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CasesService {

    private apiUrl = API_URL + 'Detective/GetAllCases';
    data: any = {};

  constructor(private http: HttpClient) { }

  getCases() {
      return this.http.get('https://jsonplaceholder.typicode.com/posts');
  }

  getCase(caseId) {
      return this.http.get( `https://jsonplaceholder.typicode.com/posts/${caseId}`);
  }

}
