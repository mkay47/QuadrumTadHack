import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/map';
import { HttpHeaders } from '@angular/common/http';
import { Case } from '../model/create-docket.model';

@Injectable({
    providedIn: 'root'
})

export class CreateService{
    private apiUrl = 'http://172.20.10.2:5000/api/Admin/AddCase';
     httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
      };

    constructor(private http: Http){}

    createCase(data: Case){
        return this.http.post(this.apiUrl,data);
    }
}

