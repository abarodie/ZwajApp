import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @Output() cancelRegister= new EventEmitter();
  model: any={};
  constructor(private authServise:AuthService) { }

  ngOnInit() {
  }
  register(){
    this.authServise.register(this.model).subscribe(
      ()=>{console.log('تم الاشتراك')},
      error=>{console.log(error)}
    )
  }

  cancel(){
    console.log('ليس الآن');
    this.cancelRegister.emit(false);
  }

}
