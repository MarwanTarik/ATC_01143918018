import { Card, Stack, Heading, Spinner, Box } from "@chakra-ui/react";
import { useGetEventByUserIdQuery } from '../app/services/events';
import type { EventResponse } from "../types/common";

function AdminDashboard({ userId }: { userId:string }) {
  const {
    data: events,
    isLoading,
    isSuccess,
    isError,
    error 
  } = useGetEventByUserIdQuery(userId) as { 
    data: EventResponse[],
    isLoading: boolean,
    isSuccess: boolean,
    isError: boolean,
    error: unknown
  };
  

  return (
    <Stack>
      <Heading as="h1" size="xl">Admin Dashboard</Heading>

      {isLoading &&  <Spinner/>}
      
      {isError && <Card.Body p={4} borderWidth="1px" borderRadius="lg">{`Error: ${error}`}</Card.Body>}
      
      {isSuccess && events && events.length > 0 ? (
        <Box>
          {events.map((event) => (
            <Card.Body key={event.id} p={4} borderWidth="1px" borderRadius="lg">
              <Card.Body>
                <Heading as="h2" size="lg">{event.name}</Heading>
                <p>{event.description}</p>
              </Card.Body>
            </Card.Body>
          ))}
        </Box>
      ) : (
        <Card.Body p={4} borderWidth="1px" borderRadius="lg">No events found.</Card.Body>
      )}
    </Stack>
  );
}

export default AdminDashboard
