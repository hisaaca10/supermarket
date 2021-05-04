import { Component, OnInit,  ElementRef, ViewChild } from '@angular/core';
import { GifsService } from '../gifs/services/gifs.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {


  @ViewChild('txtUsuario') txtUsuario!:ElementRef<HTMLInputElement>;
  @ViewChild('txtPassword') txtPassword!:ElementRef<HTMLInputElement>;

  constructor( private gifsService: GifsService ) {}

  ngOnInit(): void {
  }

  login() {
    
    const usuario = this.txtUsuario.nativeElement.value;
    const password = this.txtPassword.nativeElement.value;
    if ( usuario.trim().length === 0 ) {
      return;
    }

    this.gifsService.loginUser( usuario, password );

   
  }

}
