import { Component, OnInit } from '@angular/core';
import { UserProfileService } from '../services/user-profile.service';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { IUser } from '../interfaces/iuser';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {
  profileForm: FormGroup;
  constructor(
    private UserProfileService: UserProfileService,
    private AuthService:AuthService,
    private router: Router,
    private formbuilder: FormBuilder,
    ) {}

  ngOnInit() {
    this.profileForm = this.formbuilder.group({
      firstName: "Jim",
      lastName: "Sanders",
      birthday: "10/17/1962",
      address: "Broadway"
    });
  }

  post() {
    //const service: UserProfileService
    this.UserProfileService.post(this.profileForm.value)
    .subscribe(console.log);
  }

  onSubmit() {
    this.post()
  }
}
