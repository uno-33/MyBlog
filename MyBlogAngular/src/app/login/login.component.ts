import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form:FormGroup;


  constructor(private fb:FormBuilder, 
                private _authService: AuthService, 
                private _router: Router) {

      this.form = this.fb.group({
          username: ['',Validators.required],
          password: ['',Validators.required]
      });
  }

  login() {
      const val = this.form.value;

      if (val.username && val.password) {
          this._authService.login(val.username, val.password)
              .subscribe(
                  () => {
                      console.log("User is logged in");
                      this._router.navigateByUrl('/');
                  }
              );
      }
  }

  ngOnInit(): void {
  }

}
