import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  menu = [
    {url: '/agents', content: 'Agents Management'},
    {url: '/players', content: 'Players Management'},
    {url: '/markets', content: 'Markets Management'},
    {url: '/reports', content: 'Reports'},
    {url: '/rules', content: 'Rules'}
  ];
}
