import { Component, OnInit } from '@angular/core';
import { MdSnackBar } from '@angular/material';
import { Player } from './player.model';
import { PlayersService } from './players.service';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css'],
  providers: [PlayersService]
})
export class PlayersComponent implements OnInit {
  player: Player = new Player;

  constructor(private snackBar: MdSnackBar, private $players: PlayersService) { }

  ngOnInit() {
  }

  GetByID(id: string){
    //this.$players.GetByID(id).subscribe(data => {
    //   if (data.result) {
    //       this.player = data.result;
    //   }else{
    //     this.snackBar.open('Couldn\'t find a Player with that ID', '', {
    //       duration: 3000
    //     });
    //   }
    // }, error => {
    //   console.error(error);
    // });
  }

}
