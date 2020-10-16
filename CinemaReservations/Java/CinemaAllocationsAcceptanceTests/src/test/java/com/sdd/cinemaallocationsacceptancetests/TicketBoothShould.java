package com.sdd.cinemaallocationsacceptancetests;

import com.sdd.cinemaallocations.*;
import com.sdd.cinemaallocationsacceptancetests.helpers.StubMovieScreeningRepository;
import org.junit.Before;
import org.junit.Test;

import java.io.IOException;

import static com.google.common.truth.Truth.assertThat;

public class TicketBoothShould {

    private static final String FORD_THEATHER = "1";
    private static final String DOCK_STREET = "3";
    private static final String MADISON_THEATHER = "5";

    private TicketBooth ticketBooth;

    @Before
    public void before() throws IOException {
        MovieScreeningRepository repository =  new StubMovieScreeningRepository();
        TicketBooth ticketBooth = new TicketBooth(repository);
    }

    @Test
    public void reserve_one_seat_when_available() {
        int partyRequested = 1;

        SeatsAllocated seatsAllocated = ticketBooth.allocateSeats(new AllocateSeats(FORD_THEATHER, partyRequested));

        assertThat(seatsAllocated.reservedSeats()).hasSize(1);
        assertThat(seatsAllocated.reservedSeats().get(0).toString()).isEqualTo("A3");
    }

    @Test
    public void Reserve_multiple_seats_when_available() throws IOException {
        String showId = "3";
        int partyRequested = 3;

        MovieScreeningRepository repository =  new StubMovieScreeningRepository();
        TicketBooth ticketBooth = new TicketBooth(repository);

        SeatsAllocated seatsAllocated = ticketBooth.allocateSeats(new AllocateSeats(showId, partyRequested));

        assertThat(seatsAllocated.reservedSeats()).hasSize(3);
        assertThat(seatsAllocated.reservedSeats().get(0).toString()).isEqualTo("A6");
        assertThat(seatsAllocated.reservedSeats().get(1).toString()).isEqualTo("A7");
        assertThat(seatsAllocated.reservedSeats().get(2).toString()).isEqualTo("A8");
    }

    @Test
    public void return_SeatsNotAvailable_when_all_seats_are_unavailable() throws IOException {

        String showId = "5";
        int partyRequested = 1;

        MovieScreeningRepository repository =  new StubMovieScreeningRepository();
        TicketBooth ticketBooth = new TicketBooth(repository);

        SeatsAllocated seatsAllocated = ticketBooth.allocateSeats(new AllocateSeats(showId, partyRequested));

        assertThat(seatsAllocated).isInstanceOf(NoPossibleAllocationsFound.class);
    }

    @Test
    public void return_TooManyTicketsRequested_when_9_tickets_are_requested() throws IOException {
        String showId = "5";
        int partyRequested = 9;

        MovieScreeningRepository repository =  new StubMovieScreeningRepository();
        TicketBooth ticketBooth = new TicketBooth(repository);

        SeatsAllocated seatsAllocated = ticketBooth.allocateSeats(new AllocateSeats(showId, partyRequested));

        assertThat(seatsAllocated).isInstanceOf(TooManyTicketsRequested.class);
    }

}
