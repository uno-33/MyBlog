import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/internal/operators/first';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {

  regForm!: FormGroup;
    loading = false;
    submitted = false;
    error = '';

    constructor(
        private _formBuilder: FormBuilder,
        private _route: ActivatedRoute,
        private _router: Router,
        private _authService: AuthService
    ) { 
        // redirect to home if already logged in
        if (this._authService.userValue) { 
            this._router.navigate(['/']);
        }
        
    }

    ngOnInit() {
        this.regForm = this._formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required]
        });
    }

    // convenience getter for easy access to form fields
    get f() { return this.regForm.controls; }

    onSubmit() {
        this.submitted = true;

        // stop here if form is invalid
        if (this.regForm.invalid) {
            return;
        }

        this.loading = true;
        const val = this.regForm.value;

        this._authService.register(val.username, val.password)
            .subscribe({
                next: () => {
                    this._router.navigateByUrl('login');
                },
                error: error => {
                    this.error = error;
                    this.loading = false;
                }
            });
    }

}
