import { Component, OnInit } from '@angular/core';
import { MdSnackBar } from '@angular/material';
import { Agent } from './agent.model'
import { AgentsService } from './agents.service';

@Component({
  selector: 'app-agents',
  templateUrl: './agents.component.html',
  styleUrls: ['./agents.component.css'],
  providers: [AgentsService]
})
export class AgentsComponent implements OnInit {
  foods = [];
  agent: Agent = new Agent;
  masterAgents: Array<Agent> = [];

  constructor(private snackBar: MdSnackBar, private $agents: AgentsService) { }

  ngOnInit(){

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
    });
  }

  GetMasterAgents(){
    this.$agents.GetMasterAgents(this.agent.agentID, this.agent.agentType).subscribe(data => {
      this.masterAgents = data.result;
    }, error => {
      console.error(error);
    });
  }

}
