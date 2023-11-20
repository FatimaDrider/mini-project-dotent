import  { useEffect, useState } from 'react';
import axios from 'axios';
import { Button, Container, Header, List } from 'semantic-ui-react';
import { Activity } from '../models/activity';
import NavBar from './NavBar';
import ActivityDashbord from '../../features/activities/dashbord/ActivityDashbord';

function App() {
  const [activities,setActivitises] =useState<Activity[]>([]);
  useEffect(()=>{
    axios.get<Activity[]>('http://localhost:5000/api/activities')
    .then(response =>{
      setActivitises(response.data);
    })
  },[])
  return (
    <>
      <NavBar/>
      <Container style={{marginTop:'7em'}}>
      <ActivityDashbord activities={activities}/>
      </Container>
    </>
  );
}

export default App;
