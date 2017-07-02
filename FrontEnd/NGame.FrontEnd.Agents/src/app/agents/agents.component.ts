import { Component, OnInit } from '@angular/core';
import { MdSnackBar } from '@angular/material';
import { Agent } from './agent.model'
import { AgentsService } from './agents.service';
import { CommonsService } from './../commons/commons.service';

@Component({
  selector: 'app-agents',
  templateUrl: './agents.component.html',
  styleUrls: ['./agents.component.css'],
  providers: [AgentsService, CommonsService]
})
export class AgentsComponent implements OnInit {
  agent: Agent = new Agent;
  masterAgents: Array<Agent> = [];
  settings: any = {};
  sports: Array<any> = [];

  constructor(private snackBar: MdSnackBar, private $agents: AgentsService, private $commons: CommonsService) { }

  ngOnInit(){
    this.GetSports();
  }

  GetByID(id: string){
    this.$agents.GetByID(id).subscribe(data => {
      if (data.result) {
          this.agent = data.result;
      }else{
        this.snackBar.open('Couldn\'t find an Agent with that ID', '', {
          duration: 3000
        });
      }
    }, error => {
      console.error(error);
    }, () => {
      this.GetMasterAgents();
      this.GetSettings();
    });
  }

  GetMasterAgents(){
    this.$agents.GetMasterAgents(this.agent.agentID, this.agent.agentType).subscribe(data => {
      this.masterAgents = data.result;
    }, error => {
      console.error(error);
    });
  }

  GetSettings(){
    this.$agents.GetSettings(this.agent.agentID, this.agent.agentType).subscribe(data => {
      for(let setting of data.result.agentSettings){
        this.settings[setting.propertyName] = setting.agentSettingValue == 2? true : false;
      }
      console.log(this.settings);
    }, error => {
      console.error(error);
    });
  }

  GetSports(){
    this.$commons.GetSports().subscribe(data => {
      this.sports = data.result.sports;
      console.log(data.result.sports);
    }, error => {
      console.error(error);
    });
  }

}
