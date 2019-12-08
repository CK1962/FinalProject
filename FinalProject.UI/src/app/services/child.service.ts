import { Injectable } from '@angular/core';
import { IChild } from '../interfaces/ichild';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ChildService {
  childList: IChild[] = [];

  constructor(private http: HttpClient) {
    this.load();
  }

  private isLoaded: boolean = false;
  private async load() {
    const url: string = "https://localhost:44331/api/Child";
    this.http.get<IChild[]>(url).subscribe(data => {
      this.childList = data as IChild[];
      this.isLoaded = true;
    });
  }

  delete(childId: number) {
    // delete API
    const url: string = "https://localhost:44331/api/Child/" + childId;
    this.http.delete<IChild[]>(url).subscribe(data => {
      this.load();
    });
  }

  getAll(): IChild[] {
    if (!this.isLoaded) {
      this.load();
    }
    return this.childList;
  }

  add(child: IChild) {
    // add API
    const url: string = "https://localhost:44331/api/Child/";
    this.http.post<IChild[]>(url, child).subscribe(data => {
      this.load();
    });
  }

  update(childId: number): void {
    const child = this.childList.find(x => x.id === childId);

    // update API
    const url: string = "https://localhost:44331/api/Child/" + childId;
    this.http.put<IChild[]>(url, child).subscribe(data => {
      this.load();
    });
  }
}