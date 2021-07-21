import { HttpClient, HttpEventType } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Globals } from './globals';

@Injectable({
  providedIn: 'root'
})
export class UploadService {

  

  constructor(private http: HttpClient, private global: Globals) { }

  uploadUrl = 'api/upload';
  progress: number = 0;
  message: string = '';

  uploadFile(formData: FormData){
    this.http.post(this.global.currentHostURL() + this.uploadUrl, formData).subscribe();
  }
}
