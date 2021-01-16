import { Component, OnInit } from '@angular/core';
import { httpFactory } from '@angular/http/src/http_module';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
model : any={};
  constructor(public authservice:AuthService,private alertify:AlertifyService) { }

  ngOnInit() {
  }
  login(){
    this.authservice.login(this.model).subscribe(
      next=>{this.alertify.success('تم الدخول بنجاح')},
      error =>{this.alertify.error(error)}
    )
  }
  loggedIn(){
    return this.authservice.loggedIn()
  }

  loggedOut(){
    localStorage.removeItem('token');
    this.alertify.message('تم الخروج');
  }

}
