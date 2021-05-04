import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { SearchGifsResponse, Gif } from '../interface/gifs.interface';
import { SearchProductoResponse, Producto } from '../interface/producto.interface';


@Injectable({
  providedIn: 'root'
})
export class GifsService {

  private servicioUrl: string = '/api/';
  
  public productos: Producto[] = [];




  constructor( private http: HttpClient ) {

    this.productos = JSON.parse(localStorage.getItem('productos')!) || [];
  

    // if( localStorage.getItem('historial') ){
    //   this._historial = JSON.parse( localStorage.getItem('historial')! );
    // }

  }



  loginUser( query: string = '' , password: string) {


    const params = new HttpParams()
          .set('usuario', query )
          .set('password', password );

    this.http.get<any>(`${ this.servicioUrl }/login`, { params } )
      .subscribe( ( resp ) => {

        console.log(resp);
        
      });

  }

  buscarProductos( query: string = '' ) {

    query = query.trim().toLocaleLowerCase();
  

    const params = new HttpParams()
          .set('producto_name', query );

    this.http.get<SearchProductoResponse>(`${ this.servicioUrl }/searchProducto`, { params } )
      .subscribe( ( resp ) => {
        this.productos = resp.data;
        localStorage.setItem('productos', JSON.stringify( this.productos )  );
      });

  }


}
