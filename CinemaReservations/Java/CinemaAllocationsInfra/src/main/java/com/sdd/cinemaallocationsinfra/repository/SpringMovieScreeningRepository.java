package com.sdd.cinemaallocationsinfra.repository;

import com.sdd.cinemaallocationsinfra.repository.model.JPAMovieScreening;
import org.springframework.data.jpa.repository.JpaRepository;

//TODO Entity needs it's own JPA Model
public interface SpringMovieScreeningRepository extends JpaRepository<JPAMovieScreening, String> {
}
