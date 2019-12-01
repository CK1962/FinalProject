import { Injectable } from '@angular/core';
import { IChild } from '../interfaces/ichild';

@Injectable({
  providedIn: 'root'
})
export class ChildService {
childList: IChild[] = [];
  constructor() {
    const child1: IChild = {
      id: 1,
      name: 'Ashton',
      dob: '01/01/2010',
      moveInDate: '10/10/2010',
      house: 'Keslin'
    };

    this.add(child1);
  }

   delete(childId: number) {
    const index = this.childList.findIndex(childItem => childItem.id === childId);
    this.childList.splice(index, 1);
  }

  getAll(): IChild[] {
    return this.childList;
  }

  add(child: IChild) {
    this.childList.push(child);
  }

  update(child: IChild): void {
    var foundItem = this.childList.find(x => x.id === child.id);
  }
}