package com.sdd.cinemaallocationsinfra.controllers;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("api/CinemaAllocations")
public class CinemaAllocationsController {


    public CinemaAllocationsController() {
    }

    // GET api/SeatsSuggestions?showId=5&party=3
    @GetMapping(produces = "application/json")
    public String get() {
        return "Hello World";
    }

}
